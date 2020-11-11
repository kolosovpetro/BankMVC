using System;

namespace BankMVC.Model.Models
{
    public class Transaction
    {
        public string UserName { get; set; }    // foreign key
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        
        // navigational property
        public virtual User User { get; set; }

        public Transaction()
        {
        }

        public Transaction(string userName, double amount, DateTime transactionDate)
        {
            UserName = userName;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}