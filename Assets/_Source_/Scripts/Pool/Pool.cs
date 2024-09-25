using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject _prefab;

    [SerializeField] private int _capasity = 10;
    [SerializeField] private int _maxSize = 10;

    private ObjectPool<PoolObject> _pool;

    private void Awake()
    {
        Initilize();
    }

    private void OnValidate()
    {
        if (_prefab == null)
            throw new ArgumentNullException(nameof(_prefab));
    }

    public PoolObject Create(Vector3 position)
    {
        PoolObject obj = _pool.Get();
        obj.SetPosition(position);

        return obj;
    }

    public void Release(PoolObject obj) => _pool.Release(obj);

    private void ActionOnGet(PoolObject obj) => obj.Enable();

    private void ActionOnRelease(PoolObject obj) => obj.Disable();

    private PoolObject InitObject()
    {
        PoolObject obj = Instantiate(_prefab);
        obj.Init(this);

        return obj;
    }

    private void Initilize()
    {
        _pool = new ObjectPool<PoolObject>(
            createFunc: () => InitObject(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _capasity,
            maxSize: _maxSize);
    }
}
