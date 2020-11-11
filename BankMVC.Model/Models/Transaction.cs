using System;

namespace BankMVC.Model.Models
{
    public class Transaction
    {
        public string UserName { get; set; }    // foreign key
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}