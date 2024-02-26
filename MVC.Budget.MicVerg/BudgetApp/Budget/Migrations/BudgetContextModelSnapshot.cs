﻿// <auto-generated />
using System;
using Budget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Budget.Migrations
{
    [DbContext(typeof(BudgetContext))]
    partial class BudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Budget.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Groceries"
                        },
                        new
                        {
                            Id = -2,
                            Description = "Utilities"
                        },
                        new
                        {
                            Id = -3,
                            Description = "Entertainment"
                        },
                        new
                        {
                            Id = -4,
                            Description = "Transportation"
                        },
                        new
                        {
                            Id = -5,
                            Description = "Healthcare"
                        },
                        new
                        {
                            Id = -6,
                            Description = "Income"
                        });
                });

            modelBuilder.Entity("Budget.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Amount = 50.00m,
                            CategoryId = -1,
                            Date = new DateTime(2024, 2, 23, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5852),
                            Description = "Grocery shopping",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = -2,
                            Amount = 100.00m,
                            CategoryId = -2,
                            Date = new DateTime(2024, 2, 21, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5896),
                            Description = "Paid electricity bill",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = -3,
                            Amount = 2000.00m,
                            CategoryId = -6,
                            Date = new DateTime(2024, 2, 16, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5900),
                            Description = "Received salary",
                            TransactionType = 0
                        },
                        new
                        {
                            Id = -4,
                            Amount = 80.00m,
                            CategoryId = -3,
                            Date = new DateTime(2024, 2, 24, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5902),
                            Description = "Dinner with friends",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = -5,
                            Amount = 60.00m,
                            CategoryId = -4,
                            Date = new DateTime(2024, 2, 18, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5905),
                            Description = "Monthly bus pass",
                            TransactionType = 1
                        },
                        new
                        {
                            Id = -6,
                            Amount = 120.00m,
                            CategoryId = -5,
                            Date = new DateTime(2024, 2, 11, 15, 50, 37, 514, DateTimeKind.Local).AddTicks(5908),
                            Description = "Doctor's appointment",
                            TransactionType = 1
                        });
                });

            modelBuilder.Entity("Budget.Models.Transaction", b =>
                {
                    b.HasOne("Budget.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Budget.Models.Category", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
