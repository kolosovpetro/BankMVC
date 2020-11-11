using BankMVC.Model.Models;
using BankMVC.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BankMVC.Repositories.Repos
{
    public class TransactionRepository : RepositoryBase<Transaction>
    {
        public TransactionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}