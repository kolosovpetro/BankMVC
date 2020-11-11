namespace BankMVC.Model.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Pin { get; set; }        // pin as a string since it will be decrypted
        public double Balance { get; set; }
    }
}