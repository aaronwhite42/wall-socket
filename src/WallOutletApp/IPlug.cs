namespace WallOutletApp;

public interface IPlug
{
    IPin Positive { get; }
    IPin Negative { get; }
    IPin Ground { get; }
}

public interface IPin
{
}