using System;
using FishMarket.Domain.SeedWork;

namespace FishMarket.UnitTest.SeedWork;

public abstract class TestBase
{
    public static void AssertBrokenRule<TRule>(TestDelegate testDelegate) where TRule : class, IBusinessRule
    {
        var message = $"Expected {typeof(TRule).Name} broken rule";
        var businessRuleValidationException = Assert.Catch<BusinessRuleValidationException>(testDelegate, message);
        if (businessRuleValidationException != null)
        {
            Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
        }
    }

    [TearDown]
    public void AfterEachTest()
    {

    }
}

