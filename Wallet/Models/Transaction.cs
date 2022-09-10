using System;

namespace Wallet.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Type { get; set; }
        public string Sender { get; set; }
        public string Addressee { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CurrentUserId { get; set; }
        public User CurrentUser { get; set; }
    }
}