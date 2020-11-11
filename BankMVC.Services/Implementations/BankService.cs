using System;
using System.Collections.Generic;
using BankMVC.Auxiliary.Encode;
using BankMVC.Model.Models;
using BankMVC.Repositories.Repos;
using BankMVC.ViewModel.ViewModels;

namespace BankMVC.Services.Implementations
{
    public class BankService
    {
        private readonly UserRepository _userRepository;
        private readonly TransactionRepository _transactionRepository;

        public BankService(UserRepository userRepository, TransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
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

        public static string Encode(int pin)
        {
            return new Encoder().Encode(pin);
        }

        public User GetUserByNameAndPin(string name, string pin)
        {
            var user = _userRepository.Get(x => x.UserName == name && x.Pin == pin);
            return user;
        }

        public void DatabaseSaveChanges()
        {
            _userRepository.SaveChanges();
            _transactionRepository.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public IEnumerable<Transaction> GetUserTransactions(string userName)
        {
            return _transactionRepository.GetMany(x => x.UserName == userName);
        }
    }
}