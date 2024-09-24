using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Helper : MonoBehaviour, IGameHelper
{
    [SerializeField] private GameObject _backlight;
    [SerializeField] private BallPool _pool;

    private Ball _currentBall;

    private void Awake()
    {
        _backlight = Instantiate(_backlight, transform);
        Off();
    }

    private void Update()
    {
        if (_currentBall == null)
            return;

        if(_currentBall.IsEnabled() == false)
        {
            Off();
        }
    }

    public void Show()
    {
        Ball[] balls = _pool.GetEnableAll();

        if (balls == null || balls.Length == 0)
            throw new ArgumentNullException(nameof(balls));

        if (TryFindStep(balls, out Ball ball))
            _currentBall = ball;
        else
            _currentBall = balls[Random.Range(0, balls.Length)];

        On();
    }

    public bool HasStep()
    {
        Ball[] balls = _pool.GetEnableAll();

        if (balls == null || balls.Length == 0)
            throw new ArgumentNullException(nameof(balls));

        if (TryFindStep(balls, out Ball ball))
        {
            return true;
        }

        return false;
    }

    public void Off()
    {
        _backlight.SetActive(false);
        _currentBall = null;
    }

    private void On()
    {
        _backlight.transform.position = _currentBall.Transform.position;
        _backlight.SetActive(true);
    }

    private bool TryFindStep(Ball[] balls, out Ball ball)
    {
        const int MinBallForHelp = 3;

        ball = null;

        List<Ball> nearBalls = new List<Ball>();

        foreach (Ball ballElement in balls)
        {
            nearBalls.Add(ballElement);
            ballElement.FillNearBalls(nearBalls);

            if (nearBalls.Count >= MinBallForHelp)
            {
                ball = ballElement;
                return true;
            }

            nearBalls.Clear();
        }

        return false;
    }
}
