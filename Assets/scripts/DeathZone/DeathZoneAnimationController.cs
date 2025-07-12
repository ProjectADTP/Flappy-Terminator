using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathZoneAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimationState(bool state)
    {
        _animator.speed = state ? 1 : 0;
    }
}
