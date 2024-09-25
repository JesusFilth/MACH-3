using UnityEngine;

public class BlockBallUsable : MonoBehaviour
{
    public static BlockBallUsable Instance { get; private set; }

    public bool IsLock { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void Lock() => IsLock = true;

    public void Unlock() => IsLock = false;
}
