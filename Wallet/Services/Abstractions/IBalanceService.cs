using System.Threading.Tasks;
using Wallet.Models.ViewModels;

namespace Wallet.Services.Abstractions
{
    public interface IBalanceService
    {
        public Task<decimal> GetBalance(string userName);
        public Task<int> UserTransaction(SetBalanceViewModel setBalance, int userId);
        public Task<bool> UpBalance(SetBalanceViewModel setBalance);
    }
}