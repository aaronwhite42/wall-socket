namespace WallOutletApp;

public interface ISwitch
{
    void Flick();
    bool IsOn { get; }
}

public class Switch : ISwitch
{
    public void Flick()
    {
        IsOn = !IsOn;
    }

    public bool IsOn { get; private set; }
}