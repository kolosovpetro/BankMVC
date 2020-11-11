using System;
using System.Linq.Expressions;
using BankMVC.Auxiliary.Decode;
using BankMVC.Auxiliary.Encode;
using BankMVC.Model.Models;
using BankMVC.Repositories.Repos;
using BankMVC.Services.Interfaces;
using BankMVC.ViewModel.ViewModels;

namespace BankMVC.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly UserRepository _userRepository;

        public LoginService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUserNameAndPin(LoginViewModel model)
        {
            var pin = new Encoder().Encode(model.Pin);
            var userName = model.UserName;
            var user = _userRepository.Get(x => x.Pin == pin && x.UserName == userName);
            return user != null;
        }

        public UserBalanceViewModel GetBalance(string userName, int pin)
        {
            var currentPin = new Encoder().Encode(pin);
            var user = _userRepository.Get(x => x.Pin == currentPin && x.UserName == userName);
            if (user == null)
                throw new InvalidOperationException("No such user in database");

            var balanceModel = new UserBalanceViewModel
            {
                Balance = user.Balance,
                UserName = userName
            };

            return balanceModel;
        }

        public string Encode(int pin)
        {
            return new Encoder().Encode(pin);
        }

        public int Decode(string pin)
        {
            return new Decoder().Decode(pin);
        }

        public User GetUserByNameAndPin(Expression<Func<User, bool>> @where)
        {
            var user = _userRepository.Get(where);
            return user;
        }

        public void DatabaseSaveChanges()
        {
            _userRepository.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}