using BankMVC.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMVC.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-P87PH2B;Initial Catalog=ApiDatabase;Integrated Security=true;");
        }
    }
}