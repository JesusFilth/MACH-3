using System;
using System.Collections.Generic;
using UnityEngine;

public class Battlegraund : MonoBehaviour, IBallDestroy
{
    private const int SizeX = 5;
    private const int SizeY = 5;

    [SerializeField] private BallPool _pool;

    private void Start()
    {
        Initialize();
    }

    private void OnValidate()
    {
        if (_pool == null)
            throw new ArgumentNullException(nameof(_pool));
    }

    public void Destroy(Ball ball)
    {
        List<Ball> nearBalls = new List<Ball>();
        nearBalls.Add(ball);
        ball.FillNearBalls(nearBalls);

        Debug.Log("Destroy");//? change this
        if (nearBalls.Count >= 3)
        {
            foreach (Ball item in nearBalls)
            {
                item.Destroy();
            }
        }
        else
        {
            ball.Destroy();
        }
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
                Ball ball = _pool.GetFree();
                ball.Init(this);
                ball.SetPosition(i, j);
                ball.Enable();
            }
        }
    }
}
