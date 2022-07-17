using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Queries;
using FishMarket.Domain.Fishes;

namespace FishMarket.Application.Fishes.GetFish
{
    public class GetFishQueryHandler:IQueryHandler<GetFishQuery,FishDTO>
    {
        private readonly IFishRepository fishRepository;

        public GetFishQueryHandler(IFishRepository fishRepository)
        {
            this.fishRepository = fishRepository;
        }

        public async Task<FishDTO> Handle(GetFishQuery request, CancellationToken cancellationToken)
        {
          var fish = await this.fishRepository.GetByIdAsync(request.Id);
          return new FishDTO { Id=fish.Id.ToString(),Name=fish.Name,Price=fish.Price,ImagePath=fish.ImagePath};
        }
    }
}

