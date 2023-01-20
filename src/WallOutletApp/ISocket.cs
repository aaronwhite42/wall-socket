using System.ComponentModel;

namespace WallOutletApp;

public interface ISocket : IConnection
{
    void Connect(IPlug plug);
    bool IsConnected { get; }
    void Disconnect(IPlug plug);
}

public class Socket : ISocket
{
    public bool IsConnected => plug != null;
    private IPlug? plug;
    private bool isOn;

    public void Connect(IPlug plug)
    {
        this.plug = plug;
        this.plug?.HandleStateChanged(null, new StateChangedEventArgs{IsOn = isOn});
    }
    public void Disconnect(IPlug plug)
    {
        this.plug?.HandleStateChanged(null, new StateChangedEventArgs{IsOn = false});
        this.plug = null;
    }

    public void HandleStateChanged(object? sender, StateChangedEventArgs args)
    {
        plug?.HandleStateChanged(sender, args);
        isOn = args.IsOn;
    }
}
