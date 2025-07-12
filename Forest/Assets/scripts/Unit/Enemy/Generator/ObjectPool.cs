using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private ScoreCounter _score;

    private Queue<Enemy> _pool;

    public IEnumerable<Enemy> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        Enemy enemy;

        if (_pool.Count == 0)
        {
            enemy = Instantiate(_prefab, _container);
        }
        else
        {
            enemy = _pool.Dequeue();
        }

        enemy.gameObject.SetActive(true);
        enemy.Dead += HandleEnemyDeath;

        return enemy;
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
    }

    public void Clear()
    {
        _pool.Clear();
    }

    private void HandleEnemyDeath(Enemy deadEnemy)
    {
        _score.Add();

        deadEnemy.Dead -= HandleEnemyDeath;

        PutObject(deadEnemy);
    }
}
