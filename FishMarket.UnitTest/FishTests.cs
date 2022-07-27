using FishMarket.Domain.Fishes;
using FishMarket.Domain.Fishes.Rules;
using FishMarket.UnitTest.SeedWork;
using NSubstitute;

namespace FishMarket.UnitTest;

[TestFixture]
public class FishTests:TestBase
{
    [Test]
    public void CreateFish_IsSuccessful()
    {
        var mockFishImage = new MockImage();

        var fishImageUtility = Substitute.For<IFishImageUtility>();
        Fish.Create("Hamsi", 24.5, mockFishImage.ImageBytes, fishImageUtility);
        // Assert
    }

    [Test]
    public void GivenPriceIsZero_WhenFishIsCreating_BreaksPriceMustBeGreaterThanZero()
    {
        var mockFishImage = new MockImage();

        var fishImageUtility = Substitute.For<IFishImageUtility>();
        AssertBrokenRule<FishPriceMustBeGreaterThanZero>(() =>
        {
            Fish.Create("Lüfer", 0, mockFishImage.ImageBytes, fishImageUtility);
        });

    }

    [Test]
    public void UpdateFish_IsSuccessful()
    {
        var mockFishImage = new MockImage();
        var fishImageUtility = Substitute.For<IFishImageUtility>();
        var originalFish = Fish.Create("Hamsi", 38, mockFishImage.ImageBytes, fishImageUtility);

        var updatedFish = MockFish();
        updatedFish.Update("Hamsi", 38);

        Assert.That(originalFish, Is.EqualTo(updatedFish));
    }

    [Test]
    public void GivenPriceIsZero_WhenFishIsUpdating_BreaksPriceMustBeGreaterThanZero()
    {
        var fish = MockFish();


        var mockFishImage = new MockImage();

        var fishImageUtility = Substitute.For<IFishImageUtility>();
        AssertBrokenRule<FishPriceMustBeGreaterThanZero>(() =>
        {
            fish.Update("Lüfer", 0);
        });
    }

    private Fish MockFish()
    {
        var mockFishImage = new MockImage();
        var fishImageUtility = Substitute.For<IFishImageUtility>();
        var fish = Fish.Create("Lüfer", 25, mockFishImage.ImageBytes, fishImageUtility);
        return fish;
    }
}
