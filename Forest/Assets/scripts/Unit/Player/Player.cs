using UnityEngine;
using System;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(InputReader))]

public class Player : Unit, IInteractable
{
    private PlayerMover _mover;
    private Rotator _rotator;
    private ScoreCounter _scoreCounter;
    private InputReader _inputReader;
    private PlayerShooter _shooter;

    public event Action GameOver;

    protected override void Awake()
    {
        base.Awake();

        _rotator = GetComponent<Rotator>();
        _shooter = GetComponent<PlayerShooter>();
        _mover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _inputReader = GetComponent<InputReader>();

        _rotator.Rotate(-1);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _inputReader.Shoot += Shoot;
        _inputReader.Jump += Jump;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _inputReader.Shoot -= Shoot;
        _inputReader.Jump -= Jump;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (interactable != null)
        {
            Death();
        }
    }

    protected override void Death()
    {
        _mover.Stop();

        GameOver?.Invoke();
    }

    private void Shoot()
    {
        _shooter.Shoot();
    }

    private void Jump()
    {
        _mover.Jump();
    }
}