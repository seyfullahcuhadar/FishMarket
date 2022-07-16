using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FishMarket.Domain.Fishes;
using FishMarket.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FishMarket.Infrastructure.Domain.Fishes
{
    public class FishRepository : IFishRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FishRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task CreateAsync(Fish fish)
        {
            await dbContext.Fishes.AddAsync(fish);
        }

        public async Task<Fish> GetByIdAsync(Guid id)
        {
            return await dbContext.Fishes
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Fish>> GetAllAsync()
        {
            return await dbContext.Fishes.ToListAsync();
        }

        public void Update(Fish fish)
        {
            dbContext.Entry(fish).State = EntityState.Modified;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var fish = await dbContext.Fishes.SingleOrDefaultAsync(d=>d.Id==id);
            dbContext.Fishes.Remove(fish);
        }
    }
}

