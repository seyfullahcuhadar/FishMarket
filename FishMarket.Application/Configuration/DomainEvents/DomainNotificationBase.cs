﻿using System;
using FishMarket.Domain.SeedWork;
using Newtonsoft.Json;

namespace FishMarket.Application.Configuration.DomainEvents
{
    public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
    {
        [JsonIgnore]
        public T DomainEvent { get; }

        public Guid Id { get; }

        public DomainNotificationBase(T domainEvent)
        {
            Id = Guid.NewGuid();
            DomainEvent = domainEvent;
        }
    }
}