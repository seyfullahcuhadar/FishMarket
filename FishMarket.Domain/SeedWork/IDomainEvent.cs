using MediatR;
using System;
namespace FishMarket.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}