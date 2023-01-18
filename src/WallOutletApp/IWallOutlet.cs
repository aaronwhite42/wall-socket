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
    }

    public ISwitch Switch { get; }
    public ISocket Socket { get; }

}