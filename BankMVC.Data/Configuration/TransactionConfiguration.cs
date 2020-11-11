using System;
using BankMVC.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankMVC.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(e => e.TransactionId)
                .HasName("transaction_pkey");
            builder.Property(e => e.UserName)
                .HasColumnName("user_name");

            builder.Property(e => e.Amount)
                .HasColumnName("pin");
            builder.Property(e => e.TransactionDate)
                .HasColumnName("balance");

            builder.HasData(
                new Transaction(1, "user1", 1000, DateTime.Now),
                new Transaction(2, "user1", 1000, DateTime.Now),
                new Transaction(3, "user1", 1000, DateTime.Now)
            );
        }
    }
}