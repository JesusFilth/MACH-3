using System.Collections;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private float _delayDisable = 1f;

    private Transform _transform;
    private GameObject _gameObject;

    private Pool _pool;
    private Coroutine _showing;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
        _delay = new WaitForSeconds(_delayDisable);
    }

    private void OnEnable()
    {
        if (_showing == null)
            _showing = StartCoroutine(Showing());
    }

    private void OnDisable()
    {
        if (_showing != null)
        {
            StopCoroutine(_showing);
            _showing = null;
        }
    }

    public void Init(Pool pool) =>_pool = pool;

    public void SetPosition(Vector3 position) => _transform.position = position;

    public void Enable() => _gameObject.SetActive(true);

    public void Disable() => _gameObject.SetActive(false);

    private IEnumerator Showing()
    {
        yield return _delay;
        _pool.Release(this);
        _showing = null;
    }
}
