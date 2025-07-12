using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool(UnitAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetIsDieing(bool isDieing)
    {
        _animator.SetBool(UnitAnimatorData.Params.IsDieing, isDieing);
    }

    public void SetIsShooting(bool isShooting)
    {
        _animator.SetBool(UnitAnimatorData.Params.IsShooting, isShooting);
    }
}
