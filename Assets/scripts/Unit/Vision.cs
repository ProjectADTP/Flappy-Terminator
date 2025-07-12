using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private Front _front;

    private Vector2 _visionDirection;

    public Vector2 VisionDirection => _visionDirection;

    private void FixedUpdate()
    {
        CalculateVisionDirection();
    }

    private void CalculateVisionDirection()
    {
        _visionDirection = (_front.transform.position - transform.position).normalized;
    }
}
