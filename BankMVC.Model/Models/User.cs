using System.Collections.Generic;

namespace BankMVC.Model.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pin { get; set; }        // pin as a string since it will be decrypted
        public double Balance { get; set; }
        
        // navigational property
        public virtual ICollection<Transaction> Transactions { get; set; }

        public User()
        {
        }

        public User(int userId, string userName, string pin, double balance)
        {
            UserId = userId;
            UserName = userName;
            Pin = pin;
            Balance = balance;
        }
    }
}