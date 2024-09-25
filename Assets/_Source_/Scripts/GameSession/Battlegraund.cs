using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using UnityEngine;

public class Battlegraund : MonoBehaviour, IBallDestroy
{
    private const int MinBallForScore = 3;
    private const int PriceForMove = -1;
    private const int ScoreForOneBall = 10;

    private const int SizeX = 5;
    private const int SizeY = 5;

    [SerializeField] private int CreatePositionY = 6;

    [Inject] private Stats _stats;
    [Inject] private Pool _particlePool;
    [Inject] private IBallPool _ballsPool;
    [Inject] private IGameHelper _gameHelper;

    private void Start()
    {
        Initialize();
    }

    public void Destroy(Ball ball)
    {
        _gameHelper.Off();

        List<Ball> nearBalls = new List<Ball>();
        nearBalls.Add(ball);
        ball.FillNearBalls(nearBalls);

        _stats.AddStep(PriceForMove);

        if (nearBalls.Count >= MinBallForScore)
        {
            CheckForAddScore(nearBalls.Count);
            CreateBalls(nearBalls);
            _stats.AddScore(ScoreForOneBall * nearBalls.Count);

            foreach (Ball ballElement in nearBalls)
            {
                _particlePool.Create(GetParticleBoomPosition(ballElement.Transform));
                ballElement.Destroy();
            }
        }
        else
        {
            _particlePool.Create(GetParticleBoomPosition(ball.Transform));
            ball.Destroy();
            CreateBall(ball.PosX, CreatePositionY);
            _stats.AddScore(ScoreForOneBall);
        }
    }

    private Vector3 GetParticleBoomPosition(Transform transform)
    {
        const float offsetZ = -0.5f;

        return new Vector3(transform.position.x, transform.position.y, transform.position.z + offsetZ);
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
        Ball newBall = _ballsPool.GetRandomDisable();
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
                Ball ball = _ballsPool.GetRandomDisable();
                ball.Init(this);
                ball.SetPosition(i, j);
                ball.Enable();
            }
        }
    }
}