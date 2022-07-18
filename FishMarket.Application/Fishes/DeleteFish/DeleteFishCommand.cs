using System;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Fishes.DeleteFish
{
    public class DeleteFishCommand:ICommand
    {
        public Guid Id { get; }

        public DeleteFishCommand(Guid id)
        {
            Id = id;
        }

    }
}

