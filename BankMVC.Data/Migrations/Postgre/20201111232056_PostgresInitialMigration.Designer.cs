﻿// <auto-generated />
using System;
using BankMVC.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BankMVC.Data.Migrations.Postgre
{
    [DbContext(typeof(PostgreContext))]
    [Migration("20201111232056_PostgresInitialMigration")]
    partial class PostgresInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BankMVC.Model.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("pin");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("balance");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("TransactionId")
                        .HasName("transaction_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            Amount = 1000.0,
                            TransactionDate = new DateTime(2020, 11, 12, 0, 20, 55, 671, DateTimeKind.Local).AddTicks(5632),
                            UserName = "user1"
                        },
                        new
                        {
                            TransactionId = 2,
                            Amount = 1000.0,
                            TransactionDate = new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5196),
                            UserName = "user1"
                        },
                        new
                        {
                            TransactionId = 3,
                            Amount = 1000.0,
                            TransactionDate = new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5337),
                            UserName = "user1"
                        },
                        new
                        {
                            TransactionId = 4,
                            Amount = 555.0,
                            TransactionDate = new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5348),
                            UserName = "user2"
                        },
                        new
                        {
                            TransactionId = 5,
                            Amount = 777.0,
                            TransactionDate = new DateTime(2020, 11, 12, 0, 20, 55, 676, DateTimeKind.Local).AddTicks(5354),
                            UserName = "user3"
                        });
                });

            modelBuilder.Entity("BankMVC.Model.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("Balance")
                        .HasColumnType("double precision")
                        .HasColumnName("balance");

                    b.Property<string>("Pin")
                        .HasColumnType("text")
                        .HasColumnName("pin");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("UserId")
                        .HasName("user_pkey");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Balance = 3000.0,
                            Pin = "BCDE",
                            UserName = "user1"
                        });
                });

            modelBuilder.Entity("BankMVC.Model.Models.Transaction", b =>
                {
                    b.HasOne("BankMVC.Model.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BankMVC.Model.Models.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
