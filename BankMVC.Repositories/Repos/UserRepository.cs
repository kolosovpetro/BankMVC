using BankMVC.Model.Models;
using BankMVC.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BankMVC.Repositories.Repos
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}