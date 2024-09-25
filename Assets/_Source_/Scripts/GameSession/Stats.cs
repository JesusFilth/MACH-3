using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _steps = 10;

    public int Score { get; private set; } = 0;
    public int Steps => _steps;

    public event Action GameEnded;
    public event Action<int> StepsChanged;
    public event Action<int> ScoreChanged;

    private void Start()
    {
        StepsChanged?.Invoke(_steps);
        ScoreChanged?.Invoke(Score);
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
        Score = Mathf.Clamp(Score += score, 0, int.MaxValue);

        ScoreChanged?.Invoke(Score);
    }
}
