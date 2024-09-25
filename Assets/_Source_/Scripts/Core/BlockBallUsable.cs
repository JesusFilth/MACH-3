public class BlockBallUsable
{
    private static BlockBallUsable _instance;

    public bool IsLock { get; private set; }

    private BlockBallUsable()
    {
    }

    public static BlockBallUsable GetInstance()
    {
        if(_instance == null)
            _instance = new BlockBallUsable();

        return _instance;
    }

    public void Lock() => IsLock = true;

    public void Unlock() => IsLock = false;
}
