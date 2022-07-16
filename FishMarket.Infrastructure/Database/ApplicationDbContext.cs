using FishMarket.Domain.Fishes;
using FishMarket.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FishMarket.Infrastructure.Database
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Fish> Fishes { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is Entity entity)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        entity.ModifiedAt = DateTime.Now;
                        entity.CreatedAt = DateTime.Now;

                    }
                    else if (entityEntry.State == EntityState.Modified) 
                    {
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
            }
            return base.SaveChangesAsync();
        }

    }
}
