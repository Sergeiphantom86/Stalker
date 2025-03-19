using UnityEngine;

public class ContactPointMover : MonoBehaviour
{
    [SerializeField] private float _positionOffset;
    [SerializeField] private float _minSurfaceAngle;

    private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Obstacle _))
        {
            ContactPoint contact = collision.contacts[0];

            Vector3 targetPosition = contact.point + contact.normal * _positionOffset;

            if (IsValidContact(contact.normal))
            {
                _rigidbody.MovePosition(targetPosition);
            }
        }
    }

    public void SetRigidbody(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    private bool IsValidContact(Vector3 contactNormal)
    {
        float angle = Vector3.Angle(contactNormal, Vector3.up);

        return angle > _minSurfaceAngle;
    }
}