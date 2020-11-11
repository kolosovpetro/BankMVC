using System;
using BankMVC.Data.Context;
using BankMVC.Repositories.Repos;
using BankMVC.Services.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace BankMVC.Tests.ServiceTest
{
    [TestFixture]
    public class ServiceTests
    {
        [Test]
        public void Database_Update_Test()
        {
            var context = new SqlServerContext();
            var userRepository = new UserRepository(context);
            var transactionRepository = new TransactionRepository(context);
            var bankService = new BankService(userRepository, transactionRepository);
            
            var userName = "user1";
            var userPin = 1234;
            var amount = 50d;
            var encodedPin = BankService.Encode(userPin);
            
            var user = bankService.GetUserByNameAndPin(userName, encodedPin);

            if (user == null)
                throw new InvalidOperationException("User not found.");

            if (user.Balance >= amount)
            {
                var balance = user.Balance - amount;
                user.Balance = balance;
                bankService.UpdateUser(user);
                bankService.DatabaseSaveChanges();
            }
            
            var test = bankService.GetUserByNameAndPin(userName, encodedPin);
            test.Balance.Should().Be(1950);
        }
    }
}