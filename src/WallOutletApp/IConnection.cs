namespace WallOutletApp;

public interface IConnection
{
    void HandleStateChanged(object? sender, StateChangedEventArgs args);
}