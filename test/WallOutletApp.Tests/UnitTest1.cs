using FluentAssertions;
using NSubstitute;

namespace WallOutletApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        const bool on = true;
        const bool off = false;

        //Test drive with NSubstitute and Fluent Assertions
        // var outlet = Substitute.For<IWallOutlet>();
        var outlet = new WallOutlet(
            new Switch(),
            new Socket(
                Substitute.For<IContact>(),
                Substitute.For<IContact>(),
                Substitute.For<IContact>()
                )
            );

        // Uncovered design flaw
        // outlet.TurnOn();
        // outlet.TurnOff();
        // outlet.TurnOn();

        //It's a switch
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

        //Connecting a plug
        IPlug plug = Substitute.For<IPlug>();
        outlet.Socket.Connect(plug);

    }
}

