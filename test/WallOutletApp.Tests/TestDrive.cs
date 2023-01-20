using FluentAssertions;
using NSubstitute;

namespace WallOutletApp.Tests;

public class TestDrive
{
    private readonly IWallOutlet outlet;

    public TestDrive()
    {
        outlet = Substitute.For<IWallOutlet>();
    }

    [Fact]
    public void InitialTestDrive()
    {
        //var outlet = Substitute.For<IWallOutlet>();
        // outlet.TurnOn();
        // outlet.TurnOff();
        // outlet.TurnOn();
        // outlet.TurnOn();
        // outlet.TurnOn();
        // outlet.TurnOn();
    }


    [Fact]
    public void TestDriveSwitch()
    {
        // outlet.Switch.Flick();
        // Assert.True(outlet.Switch.IsOn);
        //Install Fluent Assertions

        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeTrue("the switch was turned on");

        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeFalse("the switch was turned off");

        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeFalse("the switch is still off");
    }
}