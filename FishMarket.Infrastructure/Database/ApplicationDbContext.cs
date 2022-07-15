using FishMarket.Domain.SeedWork;
using FishMarket.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FishMarket.Infrastructure.Database
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entityEntry in ChangeTracker.Entries()) // Iterate all made changes
            {
                if (entityEntry.Entity is Entity entity)
                {
                    if (entityEntry.State == EntityState.Added) // If you want to update TenantId when Order is added
                    {
                        entity.ModifiedAt = DateTime.Now;
                        entity.CreatedAt = DateTime.Now;

                    }
                    else if (entityEntry.State == EntityState.Modified) // If you want to update TenantId when Order is modified
                    {
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
            }
            return base.SaveChangesAsync();
        }

    }
}
