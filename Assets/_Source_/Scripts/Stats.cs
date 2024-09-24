using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _steps = 10;

    public event Action GameEnded;
    public event Action<int> StepsChanged;

    private void Start()
    {
        StepsChanged?.Invoke(_steps);
    }

    public void AddStep(int step)
    {
        _steps = Mathf.Clamp(_steps += step, 0, int.MaxValue);

        StepsChanged?.Invoke(_steps);

        if (_steps == 0)
            ToGameOver();
    }

    private void ToGameOver()
    {
        GameEnded?.Invoke();

        Debug.Log("GameOver");
    }
}
