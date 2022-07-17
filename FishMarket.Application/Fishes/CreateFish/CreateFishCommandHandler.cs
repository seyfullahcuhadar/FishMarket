using System;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Domain.Fishes;
using FishMarket.Domain.SeedWork;
using MediatR;

namespace FishMarket.Application.Fishes.CreateFish
{
    public class CreateFishCommandHandler : ICommandHandler<CreateFishCommand>
    {
        private readonly IFishImageUtility fishImageUtility;
        private readonly IFishRepository fishRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateFishCommandHandler(IFishImageUtility fishImageUtility,IFishRepository fishRepository,IUnitOfWork unitOfWork)
        {
            this.fishImageUtility = fishImageUtility;
            this.fishRepository = fishRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateFishCommand request, CancellationToken cancellationToken)
        {

            var fish = Fish.Create(request.Name,request.Price,request.ImageBytes,fishImageUtility);
            await fishRepository.CreateAsync(fish);
            await unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}

