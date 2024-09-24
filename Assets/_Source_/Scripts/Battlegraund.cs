using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Battlegraund : MonoBehaviour
{
    private const int SizeX = 5;
    private const int SizeY = 5;

    [SerializeField] private Ball[] _ballPrefabs;
    [SerializeField] private Transform _conteiner;

    private Ball[,] _balls = new Ball[SizeX, SizeY];//?

    private void Awake()
    {
        Initialize();
    }

    public void CheckNearBallsRaycast(Ball ball)
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
                Ball ball = CreateRandomBall();
                ball.Init(this);
                ball.SetPosition(i, j);

                _balls[i,j] = ball;
            }
        }
    }

    private Ball CreateRandomBall()
    {
        int randomIndex = Random.Range(0, _ballPrefabs.Length);
        return Instantiate(_ballPrefabs[randomIndex], _conteiner);
    }
}
