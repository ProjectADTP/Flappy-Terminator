using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    public void Begin()
    {
        _coroutine = StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        while (enabled)
        {
            yield return _wait;

            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);

        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _pool.GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
