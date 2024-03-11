using System;
using UnityEngine;
using static Cinemachine.AxisState;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _maxSpeed = 1.0f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask GroundLayer = 1;
    [SerializeField] private Animator _animator;

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
            //var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, 0.0f);
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
        if (_movementVector.x != 0 || _movementVector.z != 0)
        {
            _animator.SetBool(Constantes.StrMove, true);
        }
        else
        {
            _animator.SetBool(Constantes.StrMove, false);
        }

        if (Application.isMobilePlatform)
        {

        }
        else
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _movementVector, _speed, 0.0f);
            _rigidbody.AddForce(_movementVector * _speed, ForceMode.Impulse);
            transform.rotation = Quaternion.LookRotation(direct);
            _rigidbody.velocity = new Vector3(Math.Clamp(_rigidbody.velocity.x, -_maxSpeed, _maxSpeed), _rigidbody.velocity.y, 0);
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
                _animator.SetBool(Constantes.StrJump, true);

                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
            else
            {
                _animator.SetBool(Constantes.StrJump, false);
            }
        }
    }
}