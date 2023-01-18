namespace WallOutletApp;

public interface ISocket
{
    IContact Positive { get; }
    IContact Negative { get; }
    IContact Ground { get; }

    void Connect(IPlug plug);
}

public class Socket : ISocket
{
    public IContact Positive { get; }
    public IContact Negative { get; }
    public IContact Ground { get; }

    public Socket(IContact positive, IContact negative, IContact ground)
    {
        Positive = positive;
        Negative = negative;
        Ground = ground;
    }

    public void Connect(IPlug plug)
    {
        Positive.Connect(plug.Positive);
        Negative.Connect(plug.Negative);
        Ground.Connect(plug.Ground);
    }
}