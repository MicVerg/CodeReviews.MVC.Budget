using Budget.Models;
using System;
using System.Collections.Generic;

namespace Budget.Data
{
    public static class SeedData
    {
        public static List<Category> Categories => new List<Category>
        {
            new Category { Id = -1, Description = "Groceries" },
            new Category { Id = -2, Description = "Utilities" },
            new Category { Id = -3, Description = "Entertainment" },
            new Category { Id = -4, Description = "Transportation" },
            new Category { Id = -5, Description = "Healthcare" },
            new Category { Id = -6, Description = "Income" }
        };

        public static List<Transaction> Transactions => new List<Transaction>
        {
            new Transaction
            {
                Id = -1,
                Description = "Grocery shopping",
                Date = DateTime.Now.AddDays(-3),
                Amount = 50.00m,
                TransactionType = TransactionType.Expense,
                CategoryId = -1 // Groceries
            },
            new Transaction
            {
                Id = -2,
                Description = "Paid electricity bill",
                Date = DateTime.Now.AddDays(-5),
                Amount = 100.00m,
                TransactionType = TransactionType.Expense,
                CategoryId = -2 // Utilities
            },
            new Transaction
            {
                Id = -3,
                Description = "Received salary",
                Date = DateTime.Now.AddDays(-10),
                Amount = 2000.00m,
                TransactionType = TransactionType.Income,
                CategoryId = -6 // Income
            },
            new Transaction
            {
                Id = -4,
                Description = "Dinner with friends",
                Date = DateTime.Now.AddDays(-2),
                Amount = 80.00m,
                TransactionType = TransactionType.Expense,
                CategoryId = -3 // Entertainment
            },
            new Transaction
            {
                Id = -5,
                Description = "Monthly bus pass",
                Date = DateTime.Now.AddDays(-8),
                Amount = 60.00m,
                TransactionType = TransactionType.Expense,
                CategoryId = -4 // Transportation
            },
            new Transaction
            {
                Id = -6,
                Description = "Doctor's appointment",
                Date = DateTime.Now.AddDays(-15),
                Amount = 120.00m,
                TransactionType = TransactionType.Expense,
                CategoryId = -5 // Healthcare
            }
        };
    }
}
