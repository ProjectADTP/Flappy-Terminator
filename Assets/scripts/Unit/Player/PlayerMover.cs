using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private float _baseGravity;

    private void Awake()
    {
        _startPosition = transform.position;

        _rigidbody = GetComponent<Rigidbody2D>();

        _baseGravity = _rigidbody.gravityScale;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
        }
    }

    public void Reset()
    {
        _rigidbody.gravityScale = _baseGravity;
        transform.position = _startPosition;
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.gravityScale = 0;
    }
}
