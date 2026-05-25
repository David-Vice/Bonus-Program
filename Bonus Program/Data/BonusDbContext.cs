using System.Data.Entity;
using Bonus_Program.Models;

namespace Bonus_Program.Data
{
    public class BonusDbContext : DbContext
    {
        public BonusDbContext() : base("name=Local")
        {
            Database.SetInitializer(new BonusDbInitializer());
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BonusTransaction> BonusTransactions { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BonusTransaction>()
                .HasRequired(b => b.Client)
                .WithMany(c => c.BonusTransactions)
                .HasForeignKey(b => b.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BonusTransaction>()
                .HasRequired(b => b.Manager)
                .WithMany(m => m.BonusTransactions)
                .HasForeignKey(b => b.ManagerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movement>()
                .HasRequired(m => m.Product)
                .WithMany(p => p.Movements)
                .HasForeignKey(m => m.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movement>()
                .HasRequired(m => m.BonusTransaction)
                .WithMany(b => b.Movements)
                .HasForeignKey(m => m.BonusId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
