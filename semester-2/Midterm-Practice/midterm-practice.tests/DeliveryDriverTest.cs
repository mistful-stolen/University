[TestFixture]
public class DeliveryDriverTest
{
    [Test]
    public void AddItemTest()
    {
        DeliveryDriver dlvrdrvr = new DeliveryDriver(1);

        dlvrdrvr.AddItem(new MenuBox("", 100, ""));

        Assert.That(dlvrdrvr.TotalWeight, Is.EqualTo(100));
    }
}