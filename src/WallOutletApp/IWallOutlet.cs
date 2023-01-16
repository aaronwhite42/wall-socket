namespace WallOutletApp;

public interface IWallOutlet
{
    ISwitch Switch { get; }

    ITerminal Positive { get; }
    ITerminal Negative { get; }
    ITerminal Ground { get; }
}

public class WallOutlet : IWallOutlet
{
    public WallOutlet(ISwitch @switch)
    {
        Switch = @switch;
    }

    public ISwitch Switch { get; }
    public ITerminal Positive { get; }
    public ITerminal Negative { get; }
    public ITerminal Ground { get; }
}