﻿using System.Threading;
using System.Threading.Tasks;

namespace FishMarket.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}