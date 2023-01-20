using System.ComponentModel;

namespace WallOutletApp;

public interface IAppliance: IConnection
{
    IPlug Plug { get; set; }
    bool IsOn { get; }
}

public class Appliance : IAppliance
{
    public Appliance(IPlug plug)
    {
        Plug = plug;
        Plug.StateChanged += HandleStateChanged;
    }

    public IPlug Plug { get; set; }
    public bool IsOn { get; set; }
    public void HandleStateChanged(object? sender, StateChangedEventArgs args)
    {
        IsOn = args.IsOn;
    }
}