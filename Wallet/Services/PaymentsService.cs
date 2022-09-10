using System;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Enums;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IServiceProviderRepository _providerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserInfoRepository _userInfoRepository;

        public PaymentsService(IServiceProviderRepository repository, IUserRepository userRepository, IUserInfoRepository userInfoRepository)
        {
            _providerRepository = repository;
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
        }

        public PaymentViewModel GetAll()
        {
            PaymentViewModel model = new PaymentViewModel
            {
                ServiceProviders = _providerRepository.GetAll()
            };
            return model;
        }

        public async Task<int> AddPayment(AddPaymentViewModel model, int userId)
        {
            if (model.Sum <= 0) return (int) StatusCodes.NegativeBalance;
            
            var userSender = await _userRepository.GetFirstOrDefaultByIdAsync(userId);
            if (userSender is null) return (int) StatusCodes.UserNotFound;
            
            var payment = await _providerRepository.GetProviderFirsOrDefaultFromIdAsync(model.ProviderId);
            if (payment is null) return (int) StatusCodes.UserNotFound;
            
            var paymentUser = payment.UsersInfos.FirstOrDefault(u => u.PropsId == model.PropsId);
            if (paymentUser is null) return (int) StatusCodes.UserNotFound;
            if (userSender.Balance < model.Sum) return (int) StatusCodes.InsufficientFunds;
            
            userSender.Balance -= model.Sum;
            payment.Balance += model.Sum;
            paymentUser.Balance += model.Sum;
            
            await AddTransaction(userSender, payment, paymentUser, model.Sum);
            return (int) StatusCodes.Success;
        }

        public async Task AddTransaction(User user, ServiceProvider paymentsService, UserInfo paymentUser, decimal sum)
        {
            Transaction senderTransaction = new Transaction
            {
                Sum = sum,
                Type = "Платеж",
                Sender = user.AuthorizationId.ToString(),
                Addressee = paymentsService.Name,
                TransactionDate = DateTime.Now,
                CurrentUserId = user.Id
            };
            user.Transactions.Add(senderTransaction);
            _userRepository.Update(user);
            _userInfoRepository.Update(paymentUser);
            _providerRepository.Update(paymentsService);
            await _userRepository.SaveAsync();
            await _providerRepository.SaveAsync();
            await _userInfoRepository.SaveAsync();
        }
    }
}