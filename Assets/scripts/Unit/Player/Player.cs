using UnityEngine;
using System;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(Rotator))]

public class Player : Unit, IInteractable
{
    private PlayerMover _mover;
    private Rotator _rotator;
    private ScoreCounter _scoreCounter;

    private PlayerShooter _shooter;

    public event Action GameOver;

    protected override void Awake()
    {
        base.Awake();

        _rotator = GetComponent<Rotator>();
        _shooter = GetComponent<PlayerShooter>();
        _mover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();

        _rotator.Rotate(-1);
    }

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (interactable != null)
        {
            Death();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
        _shooter.SetIsActiveState(true);

        Animator.SetIsMoving(true);
    }

    protected override void Death()
    {
        _shooter.SetIsActiveState(false);
        _mover.Stop();

        GameOver?.Invoke();
    }
}