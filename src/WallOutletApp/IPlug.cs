namespace WallOutletApp;

public interface IPlug : IConnection, IComponent
{

}

public class Plug : IPlug
{
    public void HandleStateChanged(object? sender, StateChangedEventArgs args)
    {
        StateChanged?.Invoke(sender, args);
    }

    public event EventHandler<StateChangedEventArgs>? StateChanged;
}
