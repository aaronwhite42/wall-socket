using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WallOutletApp;

public interface ISwitch : IComponent
{
    void Flick();
    bool IsOn { get; }
}

public class Switch : ISwitch
{
    public event EventHandler<StateChangedEventArgs>? StateChanged;
    private bool isOn;

    public void Flick()
    {
        IsOn = !IsOn;
    }

    public bool IsOn
    {
        get => isOn;
        private set
        {
            if (isOn == value) return;
            isOn = value;
            StateChanged?.Invoke(null, new StateChangedEventArgs{IsOn = isOn});
        }
    }
}