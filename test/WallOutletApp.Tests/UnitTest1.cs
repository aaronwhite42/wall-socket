using FluentAssertions;

namespace WallOutletApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        const bool on = true;
        const bool off = false;
        var outlet = new WallOutlet(new Switch());
        // outlet.TurnOn();
        // outlet.TurnOff();
        // outlet.TurnOn();


        // outlet.Switch.Flick();
        // outlet.Switch.Flick();
        // outlet.Switch.Flick();
        // outlet.Switch.Flick();
        // outlet.Switch.Flick();

        // outlet.Switch.Flick();
        // Assert.True(outlet.Switch.IsOn);
        //Install Fluent Assertions


        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().Be(on);

        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().Be(off);

        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().Be(off);





    }
}