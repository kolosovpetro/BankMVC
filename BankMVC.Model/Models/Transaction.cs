using System;

namespace BankMVC.Model.Models
{
    public sealed class Transaction
    {
        public int TransactionId { get; set; }
        public string UserName { get; set; }    // foreign key
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        
        // navigational property
        public User User { get; set; }

        public Transaction()
        {
        }

        public Transaction(int transactionId, string userName, double amount, DateTime transactionDate)
        {
            TransactionId = transactionId;
            UserName = userName;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public Transaction(string userName, double amount, DateTime transactionDate)
        {
            UserName = userName;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}