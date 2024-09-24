using System;
using UnityEngine;

[Serializable]
public class BallSpawnModel
{
    [SerializeField] private Ball _ball;
    [SerializeField][Range(0, 100)] private float _weight = 50f;

    public Ball Ball => _ball;
    public float Weight => _weight;
}
