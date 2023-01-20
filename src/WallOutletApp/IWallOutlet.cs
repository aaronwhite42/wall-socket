namespace WallOutletApp;

public interface IWallOutlet
{
    ISwitch Switch { get; }
    ISocket Socket { get; }
}

public class WallOutlet : IWallOutlet
{
    public WallOutlet(ISwitch @switch, ISocket socket)
    {
        Switch = @switch;
        Socket = socket;

        Switch.StateChanged += (sender, args) => Socket.HandleStateChanged(sender, args);
    }

    public ISwitch Switch { get; }
    public ISocket Socket { get; }
}