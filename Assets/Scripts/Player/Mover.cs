using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private float _gravity;
    private Vector3 _velocity;
    private Transform _transform;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _gravity = -9.81f;
        _transform = transform;
    }

    public void Walk(float directionX, float directionZ)
    {
        Move(_moveSpeed * (transform.right * directionX + _transform.forward * directionZ));
    }

    public void ApplyGravity()
    {
        if (_controller.isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        _velocity.y += _gravity * Time.deltaTime;
        
        Move(_velocity);
    }

    private void Move(Vector3 motion)
    {
        _controller.Move(motion * Time.deltaTime);
    }
}