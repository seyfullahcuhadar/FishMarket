using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FishMarket.Domain.Fishes
{
    public interface IFishRepository
    {
        public Task CreateAsync(Fish fish);
        public Task<Fish> GetByIdAsync(Guid id);
        public Task<List<Fish>> GetAllAsync();
        public void Update(Fish fish);
        public Task DeleteByIdAsync(Guid id);


    }
}

