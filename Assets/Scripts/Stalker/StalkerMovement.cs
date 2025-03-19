using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ContactPointMover))]
public class StalkerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _stopDistance = 2f;
    [SerializeField] private Player _player;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _direction;
    private ContactPointMover _contactPointMover;

    private void Awake()
    {
        _transform = transform;

        _rigidbody = GetComponent<Rigidbody>();
        _contactPointMover = GetComponent<ContactPointMover>();

        _rigidbody.freezeRotation = true;
        _contactPointMover.SetRigidbody(_rigidbody);
    }

    void FixedUpdate()
    {
        _direction = _player.transform.position - _transform.position;

        if (_direction.magnitude > _stopDistance)
        {
            _direction.Normalize();

            Vector3 movementInDirection = _direction * _moveSpeed;

            _rigidbody.velocity = new Vector3(movementInDirection.x, _rigidbody.velocity.y, movementInDirection.z);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}