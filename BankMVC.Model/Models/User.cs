using System.Collections.Generic;

namespace BankMVC.Model.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Pin { get; set; }        // pin as a string since it will be decrypted
        public double Balance { get; set; }
        
        // navigational property
        public virtual ICollection<Transaction> Transactions { get; set; }

        public User()
        {
        }

        public User(string userName, string pin, double balance)
        {
            UserName = userName;
            Pin = pin;
            Balance = balance;
        }
    }
}