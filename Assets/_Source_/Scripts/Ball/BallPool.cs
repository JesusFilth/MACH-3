using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallPool : MonoBehaviour
{
    [SerializeField] private BallSpawnModel[] _ballPrefabs;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private float _capasity = 100;

    private List<Ball> _poolBalls = new List<Ball>();

    private void Awake()
    {
        Initialize();
    }

    private void OnValidate()
    {
        if (_conteiner == null)
            throw new ArgumentNullException(nameof(_conteiner));

        if (_ballPrefabs == null || _ballPrefabs.Length == 0)
            throw new ArgumentNullException(nameof(_ballPrefabs));
    }

    public Ball GetFree()
    {
        if (_poolBalls == null || _poolBalls.Count == 0)
            throw new ArgumentNullException(nameof(_poolBalls));

        Ball[] freeBalls = _poolBalls.Where(ball => ball.IsEnabled() == false).ToArray();

        if (freeBalls == null || freeBalls.Length == 0)
            throw new ArgumentNullException(nameof(freeBalls));

        int randomIndex = Random.Range(0,freeBalls.Length);

        return freeBalls[randomIndex];
    }

    private void Initialize()
    {
        Dictionary<Ball, int> _spawnPrefabs = new Dictionary<Ball, int>();

        float totalWeight = _ballPrefabs.Sum(spawnModel => spawnModel.Weight);

        foreach (BallSpawnModel spawnModel in _ballPrefabs)
        {
            int count = (int)Mathf.Round(spawnModel.Weight / totalWeight * _capasity);
            _spawnPrefabs.Add(spawnModel.Ball, count);
        }

        foreach (var objCreate in _spawnPrefabs)
        {
            for (int i = 0; i < objCreate.Value; i++)
            {
                Ball ball = Instantiate(objCreate.Key, _conteiner);
                ball.gameObject.SetActive(false);
                _poolBalls.Add(ball);
            }
        }
    }
}
