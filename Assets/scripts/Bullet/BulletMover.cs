using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vision _vision;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();    
    }

    public void SetDirection(Vision vision)
    {
        _vision = vision;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (enabled)
        { 
            _rigidbody.velocity = _vision.VisionDirection * _speed;

            yield return null;
        }
    }
}
