using System.Collections.Generic;
using Wallet.Models;

namespace Wallet.Repository.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public IEnumerable<Transaction> GetUserTransactionsById(int userId);
    }
}