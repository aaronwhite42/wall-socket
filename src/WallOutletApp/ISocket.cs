namespace WallOutletApp;

public interface ISocket
{
    void Connect(IPlug plug);
    bool IsConnected { get; }
    void Disconnect(IPlug plug);
}

public class Socket : ISocket
{
    public bool IsConnected { get; private set; }
    public void Connect(IPlug plug)
    {
        IsConnected = true;
    }
    public void Disconnect(IPlug plug)
    {
        IsConnected = false;
    }
}
