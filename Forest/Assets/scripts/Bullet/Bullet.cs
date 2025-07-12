using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(BulletMover))]
public abstract class Bullet : MonoBehaviour, IInteractable
{
    protected CollisionHandler CollisionHandler;

    protected void Awake()
    {
        CollisionHandler = GetComponent<CollisionHandler>();
    }

    protected void OnEnable()
    {
        CollisionHandler.CollisionDetected += Death;
    }

    protected void OnDisable()
    {
        CollisionHandler.CollisionDetected += Death;
    }

    protected abstract void Death(IInteractable interactable);
}
