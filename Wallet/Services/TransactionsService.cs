using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Models;
using Wallet.Models.ViewModels;
using Wallet.Repository.Interfaces;
using Wallet.Services.Abstractions;

namespace Wallet.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionRepository _db;

        public TransactionsService(ITransactionRepository db)
        {
            _db = db;
        }

        public TransactionsViewModel GetUserTransactionById(int userId)
        {
            IEnumerable<Transaction> transactions = _db.GetUserTransactionsById(userId);
            if (transactions is null) return null;
            
            TransactionsViewModel model = new TransactionsViewModel()
            {
                Transactions = transactions,
                Model = new FiltrationViewModel()
            };
            return model;
        }
    }
}