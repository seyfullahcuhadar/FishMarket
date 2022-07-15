using FishMarket.Domain.SeedWork;
using FishMarket.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;


namespace FishMarket.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext bankContext;

        public UnitOfWork(
            ApplicationDbContext bankContext)
        {
            this.bankContext = bankContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {

            return await bankContext.SaveChangesAsync(cancellationToken);
        }
    }
}