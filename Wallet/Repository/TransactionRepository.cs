using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Data;
using Wallet.Models;
using Wallet.Repository.Interfaces;

namespace Wallet.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WalletContext _db;

        public TransactionRepository(WalletContext db)
        {
            _db = db;
        }

        public IEnumerable<Transaction> GetAll() => _db.Transactions;

        public void Create(Transaction item) => _db.Transactions.Add(item);

        public void Update(Transaction item) => _db.Transactions.Update(item);

        public void Remove(Transaction item) => _db.Transactions.Remove(item);

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        public IEnumerable<Transaction> GetUserTransactionsById(int userId) =>
            _db.Transactions.Where(u => u.CurrentUserId == userId);
    }
}