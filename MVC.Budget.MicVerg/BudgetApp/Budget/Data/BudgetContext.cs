using Budget.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options)
             : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Transactions) // A category can have many transactions
                .WithOne(t => t.Category)    // Each transaction belongs to one category
                .HasForeignKey(t => t.CategoryId) // Foreign key property in the Transaction entity
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete behavior

            modelBuilder.Entity<Category>().HasData(SeedData.Categories);
            modelBuilder.Entity<Transaction>().HasData(SeedData.Transactions);
        }
    }
}
