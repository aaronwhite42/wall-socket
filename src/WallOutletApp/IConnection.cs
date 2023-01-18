namespace WallOutletApp;

public interface IConnection<T> where T : class
{
    bool IsConnected { get; }
    void Connect(T obj);
    void Disconnect(T obj);
}