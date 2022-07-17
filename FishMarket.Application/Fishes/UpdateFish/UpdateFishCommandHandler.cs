using System;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Domain.Fishes;
using FishMarket.Domain.SeedWork;
using MediatR;

namespace FishMarket.Application.Fishes.UpdateFish
{
    public class UpdateFishCommandHandler:ICommandHandler<UpdateFishCommand>
    {
        private readonly IFishRepository fishRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateFishCommandHandler(IFishRepository fishRepository,IUnitOfWork unitOfWork)
        {
            this.fishRepository = fishRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateFishCommand request, CancellationToken cancellationToken)
        {
           var fish = await fishRepository.GetByIdAsync(request.Id);
            fish.Update(request.Name, request.Price);
            await unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

