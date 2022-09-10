using System.Threading.Tasks;
using Wallet.Models;
using Wallet.Models.ViewModels;

namespace Wallet.Services.Abstractions
{
    public interface IPaymentsService
    {
        public PaymentViewModel GetAll();
        public Task<int> AddPayment(AddPaymentViewModel model, int userId);
        public Task AddTransaction(User user, ServiceProvider paymentsService, UserInfo paymentUser, decimal sum);
    }
}