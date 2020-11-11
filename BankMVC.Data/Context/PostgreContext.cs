using BankMVC.Data.Configuration;
using BankMVC.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMVC.Data.Context
{
    public sealed class PostgreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public PostgreContext()
        {
        }

        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;User Id=postgres;Password=postgres;Database=BankMVC;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}