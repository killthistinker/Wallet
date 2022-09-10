using Wallet.Models.ViewModels;

namespace Wallet.Services.Abstractions
{
    public interface ITransactionsService
    {
        public TransactionsViewModel GetUserTransactionById(int userId);
    }
}