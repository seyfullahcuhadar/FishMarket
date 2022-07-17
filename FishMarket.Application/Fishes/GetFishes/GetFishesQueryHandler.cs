using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Queries;
using FishMarket.Domain.Fishes;
using System.Linq;

namespace FishMarket.Application.Fishes.GetFishes
{
    public class GetFishesQueryHandler: IQueryHandler<GetFishesQuery,List<FishDTO>>
    {
        private readonly IFishRepository fishRepository;

        public GetFishesQueryHandler(IFishRepository fishRepository)
        {
            this.fishRepository = fishRepository;
        }

        public async Task<List<FishDTO>> Handle(GetFishesQuery request, CancellationToken cancellationToken)
        {
            var fishes = (await fishRepository.GetAllAsync()).
                Select(f => new FishDTO { Name = f.Name, ImagePath = f.ImagePath, Price = f.Price,Id=f.Id.ToString()})
                .ToList();
            return fishes;
        }
    }
}

