using BankMVC.Model.Models;
using BankMVC.ViewModel.ViewModels;

namespace BankMVC.Services.Interfaces
{
    public interface IBankService
    {
        bool ValidateUserNameAndPin(LoginViewModel model);
        UserBalanceViewModel GetBalance(string userName, int pin);
        string Encode(int pin);
        int Decode(string pin);
        User GetUserByNameAndPin(string name, string pin);
        void DatabaseSaveChanges();
        void UpdateUser(User user);
    }
}