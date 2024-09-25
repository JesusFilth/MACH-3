using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _steps = 10;

    private int _score = 0;

    public event Action GameEnded;
    public event Action<int> StepsChanged;
    public event Action<int> ScoreChanged;

    private void Start()
    {
        StepsChanged?.Invoke(_steps);
        ScoreChanged?.Invoke(_score);
    }

    public void AddStep(int step)
    {
        _steps = Mathf.Clamp(_steps += step, 0, int.MaxValue);

        StepsChanged?.Invoke(_steps);

        if (_steps == 0)
            GameEnded?.Invoke();
    }

    public void AddScore(int score)
    {
        _score = Mathf.Clamp(_score += score, 0, int.MaxValue);

        ScoreChanged?.Invoke(_score);
    }
}
