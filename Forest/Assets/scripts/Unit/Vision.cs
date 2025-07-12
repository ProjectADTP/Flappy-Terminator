using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private Front _front;

    public Vector2 Direction { get; private set; }

    private void FixedUpdate()
    {
        CalculateVisionDirection();
    }

    private void CalculateVisionDirection()
    {
        Direction = (_front.transform.position - transform.position).normalized;
    }
}
