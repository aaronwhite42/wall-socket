namespace WallOutletApp;

public interface IComponent
{
    event EventHandler<StateChangedEventArgs>? StateChanged;
}