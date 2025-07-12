using UnityEngine;
using System.Collections;

public class UnitDeathScene : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
