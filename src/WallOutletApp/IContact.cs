namespace WallOutletApp;

public interface IContact : IConnection<IPin>

{

}

public class Contact : IContact
{
    public bool IsConnected { get; private set; }

    public void Connect(IPin pin)
    {
        IsConnected = true;
    }

    public void Disconnect(IPin pin)
    {
        IsConnected = false;
    }
}