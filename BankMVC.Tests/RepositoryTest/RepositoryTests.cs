using System.Linq;
using BankMVC.Data.Context;
using BankMVC.Repositories.Repos;
using FluentAssertions;
using NUnit.Framework;

namespace BankMVC.Tests.RepositoryTest
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void Transaction_Repository_Test()
        {
            var context = new SqlServerContext();
            var repo = new TransactionRepository(context);
            repo.GetAll().Count().Should().Be(3);
            repo.GetAll().ToList()[0].UserName.Should().Be("user1");
            repo.GetAll().ToList()[1].UserName.Should().Be("user2");
            repo.GetAll().ToList()[2].UserName.Should().Be("user3");
        }

        [Test]
        public void User_Repository_Test()
        {
            var context = new SqlServerContext();
            var repo = new UserRepository(context);
            repo.GetAll().Count().Should().Be(3);
            repo.GetAll().ToList()[0].UserName.Should().Be("user1");
            repo.GetAll().ToList()[1].UserName.Should().Be("user2");
            repo.GetAll().ToList()[2].UserName.Should().Be("user3");
        }
    }
}