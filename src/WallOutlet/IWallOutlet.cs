namespace WallOutlet.Console;

internal interface IWallOutlet
{
    void TurnOn();
    void TurnOff();

    bool IsOn { get; }

    ITerminal Positive { get; }
    ITerminal Negative { get; }
    ITerminal Ground { get; }
}