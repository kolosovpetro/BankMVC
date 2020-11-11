using BankMVC.Auxiliary.Encode;
using BankMVC.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankMVC.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId)
                .HasName("user_pkey");

            builder.HasMany(e => e.Transactions)
                .WithOne(e => e.User);

            builder.Property(e => e.Balance)
                .HasColumnName("balance");
            builder.Property(e => e.UserName)
                .HasColumnName("user_name");
            builder.Property(e => e.Pin)
                .HasColumnName("pin");

            builder.HasData(
                new User(1, "user1", new Encoder().Encode(1234), 3000)
            );
        }
    }
}