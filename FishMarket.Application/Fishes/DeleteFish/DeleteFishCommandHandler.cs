using System;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Domain.Fishes;
using FishMarket.Domain.SeedWork;
using MediatR;

namespace FishMarket.Application.Fishes.DeleteFish
{
    public class DeleteFishCommandHandler:ICommandHandler<DeleteFishCommand>
    {
        private readonly IFishRepository fishRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteFishCommandHandler(IFishRepository fishRepository,IUnitOfWork unitOfWork,IFishImageUtility fishImageUtility)
        {
            this.fishRepository = fishRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteFishCommand request, CancellationToken cancellationToken)
        {
            await fishRepository.DeleteByIdAsync(request.Id);
            await unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

