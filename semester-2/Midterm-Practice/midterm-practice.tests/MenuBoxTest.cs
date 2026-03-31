[TestFixture]
public class MenuBoxTest
{
    [TestCase (300, 800)]
    [TestCase (1000, 1500)]
    [TestCase (3000, 3000)]
    public void CalculatePriceWithPriority(int weight, int expected)
    {
        MenuBox mnbx = new MenuBox("", weight, "");

        Assert.That(mnbx.CalculatePrice(true), Is.EqualTo(expected));
    }

    [TestCase (300, 800)]
    [TestCase (1000, 1500)]
    [TestCase (3000, 3000)]
    public void CalculatePriceWithNoPriority(int weight, int expected)
    {
        MenuBox mnbx = new MenuBox("", weight, "");

        Assert.That(mnbx.CalculatePrice(false), Is.EqualTo(expected));
    }

    [Test]
    public void CalculatePriceUnsuccessfulTest()
    {
        MenuBox mnbx = new MenuBox("", 3001, "");

        Assert.Throws<FoodTooHeavyException>(() => mnbx.CalculatePrice(false));
    }
}