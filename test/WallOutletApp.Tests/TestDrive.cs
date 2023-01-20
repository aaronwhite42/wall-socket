using FluentAssertions;
using NSubstitute;

namespace WallOutletApp.Tests;

public class TestDrive
{
    private readonly IWallOutlet outlet;
    private readonly IPlug plug;
    private readonly IAppliance appliance;

    public TestDrive()
    {
        // outlet = Substitute.For<IWallOutlet>();
        // outlet = new WallOutlet(Substitute.For<ISwitch>());
        outlet = new WallOutlet(
            new Switch(),
            new Socket()
            );
        plug = new Plug();
        appliance = new Appliance(plug);
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

    [Fact]
    public void TestDrivePlug()
    {
        outlet.Socket.Connect(plug);
        outlet.Socket.IsConnected.Should().BeTrue();

        outlet.Socket.Disconnect(plug);
        outlet.Socket.IsConnected.Should().BeFalse();
    }

    [Fact]
    public void TestDriveAppliance()
    {
        // plug in the appliance, then flick the switch
        outlet.Socket.Connect(appliance.Plug);
        outlet.Switch.Flick();
        appliance.IsOn.Should().BeTrue();

        // turn it off
        outlet.Switch.Flick();
        appliance.IsOn.Should().BeFalse();

        // turn it on then unplug it
        outlet.Switch.Flick();
        outlet.Socket.Disconnect(appliance.Plug);
        appliance.IsOn.Should().BeFalse("the appliance was unplugged from the socket");
        outlet.Socket.IsConnected.Should().BeFalse();

        // connect the plug back in while the switch is still on
        outlet.Switch.IsOn.Should().BeTrue();
        outlet.Socket.Connect(appliance.Plug);
        appliance.IsOn.Should().BeTrue();

        //When the switch is off, and the appliance is plugged in
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeFalse();
        outlet.Socket.Connect(appliance.Plug);
        appliance.IsOn.Should().BeFalse();

        // then when the switch is turned on, the appliance is on
        outlet.Switch.Flick();
        appliance.IsOn.Should().BeTrue();
    }
}