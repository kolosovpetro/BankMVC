using System;
using System.Linq.Expressions;
using BankMVC.Model.Models;
using BankMVC.ViewModel.ViewModels;

namespace BankMVC.Services.Interfaces
{
    public interface ILoginService
    {
        bool ValidateUserNameAndPin(LoginViewModel model);
        UserBalanceViewModel GetBalance(string userName, int pin);
        string Encode(int pin);
        int Decode(string pin);
        User GetUserByNameAndPin(Expression<Func<User, bool>> where);
        void DatabaseSaveChanges();
        void UpdateUser(User user);
    }
}