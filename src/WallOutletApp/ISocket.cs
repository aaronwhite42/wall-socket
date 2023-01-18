namespace WallOutletApp;

public interface ISocket : IConnection<IPlug>
{
    IContact Positive { get; }
    IContact Negative { get; }
    IContact Ground { get; }
}

public class Socket : ISocket
{
    public IContact Positive { get; }
    public IContact Negative { get; }
    public IContact Ground { get; }
    public bool IsConnected { get; private set; }

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
        IsConnected = Positive.IsConnected &&
                      Negative.IsConnected &&
                      Ground.IsConnected;
    }

    public void Disconnect(IPlug plug)
    {
        Positive.Disconnect(plug.Positive);
        Negative.Disconnect(plug.Negative);
        Ground.Disconnect(plug.Ground);
        IsConnected = Positive.IsConnected &&
                      Negative.IsConnected &&
                      Ground.IsConnected;;
    }
}