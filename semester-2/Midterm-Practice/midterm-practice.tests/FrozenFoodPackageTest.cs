using System.Runtime.CompilerServices;

[TestFixture]
public class FrozenFoodPackageTest
{
    [Test]
    public void CalculatePriceUnsuccessfulTest()
    {
        Assert.Throws<DeliveryException>(() => new FrozenFoodPackage(200, "", Wrapper.Frozen).CalculatePrice(true));
    }

    [Test]
    public void ClassConstructionUnsuccessfulTest()
    {
        Assert.Throws<InvalidPackageException>(() => new FrozenFoodPackage(0, "", Wrapper.Standard));
    }
}