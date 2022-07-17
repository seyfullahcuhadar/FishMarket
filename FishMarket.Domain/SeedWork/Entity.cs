using System;
using System.Collections.Generic;

namespace FishMarket.Domain.SeedWork
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

    }
}