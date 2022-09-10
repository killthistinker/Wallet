using System;
using System.Threading.Tasks;
using Wallet.Enums;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Services
{
    public class BalanceService : IBalanceService
    {
       private readonly IUserRepository _repository;

        public BalanceService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetBalance(string userName)
        {
            var user = await _repository.GetFirstOrDefaultByNameAsync(userName);
            if (user is null) return -1;
            return user.Balance;
        }
        public async Task<bool> UpBalance(SetBalanceViewModel setBalance)
        {
            try
            {
                if (setBalance.Balance <= 0) return false;
                var user = await _repository.GetFirstOrDefaultByUserIdAsync(setBalance.UserId);
                if (user is null) return false;
                user.Balance += setBalance.Balance;
                _repository.Update(user);
                await _repository.SaveAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> UserTransaction(SetBalanceViewModel setBalance, int userId)
        {
            if (setBalance.Balance <= 0) return (int)StatusCodes.NegativeBalance;
            
            var userSender = await _repository.GetFirstOrDefaultByIdAsync(userId);
            if (userSender is null) return (int) StatusCodes.UserNotFound;
            
            if (userSender.AuthorizationId == setBalance.UserId) return (int)StatusCodes.ReplenishYourself;
            
            var userAddressee = await _repository.GetFirstOrDefaultByUserIdAsync(setBalance.UserId);
            if (userAddressee is null) return (int) StatusCodes.UserNotFound;
           
            if (userSender.Balance < setBalance.Balance) return (int) StatusCodes.InsufficientFunds;
            
            userSender.Balance -= setBalance.Balance;
            userAddressee.Balance += setBalance.Balance;
            
            AddTransaction(userSender, userAddressee, setBalance.Balance);
            _repository.Update(userSender);
            _repository.Update(userAddressee);
            await _repository.SaveAsync();
            return (int) StatusCodes.Success;
        }
        
        public void AddTransaction(User userSender, User userAddressee, decimal balance)
        {
            Transaction senderTransaction = new Transaction
            {
                Sum = balance,
                Type = "Перевод",
                Sender = userSender.AuthorizationId.ToString(),
                Addressee = userAddressee.AuthorizationId.ToString(),
                TransactionDate = DateTime.Now,
                CurrentUserId = userSender.Id
            };
            Transaction addresseeTransaction = new Transaction
            {
                Sum = balance,
                Type = "Перевод",
                Sender = userSender.AuthorizationId.ToString(),
                Addressee = userAddressee.AuthorizationId.ToString(),
                TransactionDate = DateTime.Now,
                CurrentUserId = userAddressee.Id
            };
            userSender.Transactions.Add(senderTransaction);
            userAddressee.Transactions.Add(addresseeTransaction);
        }
        
    }
}