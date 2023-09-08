using System;
using UnityEditor.Profiling;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _maxSpeed = 1.0f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask GroundLayer = 1;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;

    public float Speed => _speed;

    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.1f, GroundLayer);
        }
    }

    private Vector3 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>(); //GroundLayer != gameObject.layer
    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        if (Application.isMobilePlatform)
        {

        }
        else
        {
            if (Math.Abs(_rigidbody.velocity.x) >= _maxSpeed)
                _rigidbody.velocity = new Vector3(_maxSpeed * _rigidbody.velocity.normalized.x, _rigidbody.velocity.y, _rigidbody.velocity.z);

            _rigidbody.AddForce(_movementVector * _speed, ForceMode.Impulse);
        }
           
    }

    private void Jump()
    {
        if (Application.isMobilePlatform)
        {

        }
        else
        {
            if (_isGrounded && (Input.GetAxis("Jump") > 0))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}
