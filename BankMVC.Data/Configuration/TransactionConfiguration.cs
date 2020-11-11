using System;
using BankMVC.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankMVC.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserName)
                .HasColumnName("user_name");
            builder.Property(e => e.Pin)
                .HasColumnName("pin");
            builder.Property(e => e.Balance)
                .HasColumnName("balance");

            builder.HasData(
                new Transaction("user1", 1000, DateTime.Now),
                new Transaction("user2", 555, DateTime.Now),
                new Transaction("user3", 777, DateTime.Now)
            );
        }
    }
}