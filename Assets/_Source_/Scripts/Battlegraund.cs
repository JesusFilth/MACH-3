using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battlegraund : MonoBehaviour, IBallDestroy
{
    private const int MinBallForScore = 3;
    private const int PriceForMove = -1;

    private const int SizeX = 5;
    private const int SizeY = 5;

    [SerializeField] private BallPool _pool;
    [SerializeField] private Stats _stats;
    [SerializeField] private int CreatePositionY = 6;

    private void Start()
    {
        Initialize();
    }

    private void OnValidate()
    {
        if (_pool == null)
            throw new ArgumentNullException(nameof(_pool));

        if (_stats == null)
            throw new ArgumentNullException(nameof(_stats));
    }

    public void Destroy(Ball ball)
    {
        List<Ball> nearBalls = new List<Ball>();
        nearBalls.Add(ball);
        ball.FillNearBalls(nearBalls);

        _stats.AddStep(PriceForMove);

        if (nearBalls.Count >= MinBallForScore)
        {
            CheckForAddScore(nearBalls.Count);
            CreateBalls(nearBalls);

            foreach (Ball item in nearBalls)
                item.Destroy();
        }
        else
        {
            ball.Destroy();
            CreateBall(ball.PosX, CreatePositionY);
        }
    }

    private void CheckForAddScore(int ballCount)
    {
        _stats.AddStep(ballCount-1);
    }

    private void CreateBalls(List<Ball> nearBalls)
    {
        nearBalls.OrderBy(ball => ball.PosX);
        Dictionary<int, int> newBalls = new Dictionary<int, int>();

        foreach (Ball item in nearBalls)
        {
            if (newBalls.ContainsKey(item.PosX))
                newBalls[item.PosX]++;
            else
                newBalls[item.PosX] = 1;
        }

        foreach (var key in newBalls)
        {
            for (int i = 0; i < key.Value; i++)
            {
                CreateBall(key.Key, CreatePositionY + i);
            }
        }
    }

    private void CreateBall(int x, int y)
    {
        Ball newBall = _pool.GetRandomDisable();
        newBall.Init(this);
        newBall.SetPosition(x, y);
        newBall.Enable();
    }

    private void Initialize()
    {
        InitBalls();
    }

    private void InitBalls()
    {
        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                Ball ball = _pool.GetRandomDisable();
                ball.Init(this);
                ball.SetPosition(i, j);
                ball.Enable();
            }
        }
    }
}