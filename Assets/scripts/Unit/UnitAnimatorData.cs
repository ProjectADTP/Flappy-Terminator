using UnityEngine;

public class UnitAnimatorData : MonoBehaviour
{
    public static class Params
    {
        public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        public static readonly int IsShooting = Animator.StringToHash(nameof(IsShooting));
        public static readonly int IsDieing = Animator.StringToHash(nameof(IsDieing));
    }
}
