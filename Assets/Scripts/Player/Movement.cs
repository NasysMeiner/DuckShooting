using System;
using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _maxSpeed = 1.0f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask GroundLayer = 1;

    [SerializeField] private List<Rigidbody> _rigidbodys;
    [SerializeField] private List<CapsuleCollider> _colliders;

    public float Speed => _speed;

    private bool _isGrounded
    {
        get
        {
            foreach (var _collider in _colliders)
            {
                var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

                return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.1f, GroundLayer);
            }

            return true;
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
        //_collider = GetComponent<CapsuleCollider>(); //GroundLayer != gameObject.layer
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
            foreach(var _rigidbody in _rigidbodys)
            {
                if (Math.Abs(_rigidbody.velocity.x) >= _maxSpeed)
                    _rigidbody.velocity = new Vector3(_maxSpeed * _rigidbody.velocity.normalized.x, _rigidbody.velocity.y, _rigidbody.velocity.z);

                _rigidbody.AddForce(_movementVector * _speed, ForceMode.Impulse);
            }
        }
           
    }

    private void Jump()
    {
        if (Application.isMobilePlatform)
        {

        }
        else
        {
            foreach (var _rigidbody in _rigidbodys)
            {
                if (_isGrounded && (Input.GetAxis("Jump") > 0))
                {
                    _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                }
            }
        }
    }
}
