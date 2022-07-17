using System;
using System.Collections.Generic;
using FishMarket.Application.Configuration.Queries;
using FishMarket.Application.Fishes.GetFish;

namespace FishMarket.Application.Fishes.GetFish
{
    public class GetFishQuery:IQuery<FishDTO>
    {
        public Guid Id { get;}
        public GetFishQuery(Guid id)
        {
            this.Id = id;
        }
    }
}

