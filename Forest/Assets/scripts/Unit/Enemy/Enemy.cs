using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : Unit, IInteractable
{
    [SerializeField] private UnitDeathScene UnitDeathPrefab;

    public event Action<Enemy> Dead;

    private bool _isDead;

    protected override void OnEnable()
    {
        base.OnEnable();

        _isDead = false;
    }

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (_isDead) return;

        if (interactable is PlayerBullet or Player)
        {
            _isDead = true;

            Instantiate(UnitDeathPrefab, transform.position, transform.rotation);

            Death();
        }
    }

    protected override void Death()
    {
        Dead?.Invoke(this);

        gameObject.SetActive(false);
    }
}