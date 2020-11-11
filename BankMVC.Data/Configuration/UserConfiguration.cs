using BankMVC.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankMVC.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(e => e.Transactions)
                .WithOne(e => e.User);

            builder.Property(e => e.Balance)
                .HasColumnName("balance");
            builder.Property(e => e.UserName)
                .HasColumnName("user_name");
            builder.Property(e => e.Pin)
                .HasColumnName("pin");
        }
    }
}