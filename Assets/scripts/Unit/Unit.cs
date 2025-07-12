using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(UnitAnimator))]
[RequireComponent(typeof(Vision))]

public abstract class Unit : MonoBehaviour
{
    protected CollisionHandler CollisionHandler;
    protected UnitAnimator Animator;
    protected Vision Vision;

    protected virtual void Awake()
    {
        Vision = GetComponent<Vision>();
        CollisionHandler = GetComponent<CollisionHandler>();
        Animator = GetComponent<UnitAnimator>();
    }

    protected virtual void OnEnable()
    {
        CollisionHandler.CollisionDetected += ProcessCollision;
    }

    protected virtual void OnDisable()
    {
        CollisionHandler.CollisionDetected += ProcessCollision;
    }

    protected abstract void Death();

    protected abstract void ProcessCollision(IInteractable interactable);
}
