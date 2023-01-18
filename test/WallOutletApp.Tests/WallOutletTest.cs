using FluentAssertions;
using NSubstitute;

namespace WallOutletApp.Tests;

public class WallOutletTest
{
    private readonly IWallOutlet outlet;
    private readonly IPlug plug;

    public WallOutletTest()
    {
        outlet = new WallOutlet(
            new Switch(),
            new Socket(
                new Contact(),
                new Contact(),
                new Contact()
            )
        );

        plug = Substitute.For<IPlug>();
    }

    [Fact]
    public void TestSwitchFlicking()
    {
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeTrue();

        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeFalse();

        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeFalse();
    }

    [Fact]
    public void TestPlugConnection()
    {
        //Connecting a plug
        outlet.Socket.Connect(plug);
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeTrue();

        // Compound state between properties
        outlet.IsLive.Should().BeTrue();

        // Turn the switch off
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeFalse();
        outlet.IsLive.Should().BeFalse();

        // Turn the switch on, then disconnect plug
        outlet.Switch.Flick();
        outlet.Socket.Disconnect(plug);
        outlet.IsLive.Should().BeFalse();
        outlet.Switch.IsOn.Should().BeTrue();
    }

    [Fact]
    public void TestPlugConnectedBeforeFlickingSwitchOn()
    {
        outlet.Switch.Flick();
        outlet.Switch.IsOn.Should().BeTrue();
        outlet.IsLive.Should().BeFalse();
        outlet.Socket.Connect(plug);
        outlet.IsLive.Should().BeTrue();
    }
}

