using System.Collections.Generic;

namespace Wallet.Models.ViewModels
{
    public class TransactionsViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public FiltrationViewModel Model { get; set; }
    }
}