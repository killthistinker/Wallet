using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Wallet.Models
{
    public class User : IdentityUser<int>
    {
        public decimal Balance { get; set; }
        public int AuthorizationId { get; set; }
        public List<Transaction> Transactions { get; set; }

        public User()
        {
            Transactions = new List<Transaction>();
        }
    }
}