using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float DetectionRadius = 0.75f;

    [SerializeField] private ColorType _type;
    [SerializeField] private LayerMask _ballMask;

    private IBallDestroy _battlegraund;
    private Transform _transform;
    private GameObject _gameObject;

    private Vector3[] _directions = {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right
    };

    public Transform Transform => _transform;
    public ColorType Type => _type;
    public int PosX { get; private set; }
    public int PosY { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
    }

    private void OnMouseDown()
    {
        if (BlockBallUsable.GetInstance().IsLock)
            return;

        _battlegraund.Destroy(this);
    }

    public bool IsEnabled() => _gameObject.activeSelf;

    public void Enable()
    {
        _gameObject.SetActive(true);
    }

    public void Destroy()
    {
        _gameObject.SetActive(false);
    }

    public void FillNearBalls(List<Ball> nearBalls)
    {
        foreach (Vector3 direction in _directions)
        {
            if(Physics.Raycast(_transform.position, direction, out RaycastHit hit, DetectionRadius, _ballMask))
            {
                if (hit.collider.TryGetComponent(out Ball nearBall))
                {
                    if (nearBall.Type != _type)
                        continue;

                    if(nearBalls.Contains(nearBall) == false)
                    {
                        nearBalls.Add(nearBall);
                        nearBall.FillNearBalls(nearBalls);
                    }
                }
            }
        }
    }

    public void Init(IBallDestroy battlegraund)
    {
        _battlegraund = battlegraund;
    }

    public void SetPosition(int x, int y)
    {
        PosX = x;
        PosY = y;

        _transform.position = new Vector3(x, y, _transform.position.z);
    }
}