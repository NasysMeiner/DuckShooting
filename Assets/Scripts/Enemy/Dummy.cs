using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dummy : MonoBehaviour
{
    [SerializeField] private float _forceHit = 50;
    [SerializeField] private float _speedRotation = 1;
    [SerializeField] private float _speedMove = 2;

    private Rigidbody _rigidbody;
    private Vector3 _forward;
    private Vector3 _startPosition;
    private Quaternion _startRotate;

    private Vector3 _direction => _startPosition - transform.position;
    private Vector3 _directionRotate => new Vector3(_startRotate.x != transform.rotation.x ? _speedRotation : 0, _startRotate.y != transform.rotation.y ? _speedRotation : 0, _startRotate.z != transform.rotation.z ? _speedRotation : 0);

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _forward = Vector3.up;
        _startPosition = transform.localPosition;
        _startRotate = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IBullet bullet))
        {
            Vector3 direction = transform.position - other.transform.position;
            //Debug.Log(other);
            Debug.Log(transform.position + " - " + other.transform.localPosition);
            _rigidbody.AddForceAtPosition(direction * _forceHit, other.transform.position);
        }
    }

    private void FixedUpdate()
    {
        Move();
        MoveRotation();
    }

    private void Move()
    {
        Vector3 NewPos = new Vector3(_rigidbody.velocity.x + _direction.x * _speedMove, _rigidbody.velocity.y + _direction.y * _speedMove, 0);
        _rigidbody.velocity = NewPos;
        //_rigidbody.AddForce(NewPos);
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, _startPosition, _speedMove * Time.fixedDeltaTime);
        //transform.position = NewPos;
    }

    private void MoveRotation()
    {
        if (transform.rotation != _startRotate)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, Vector3.forward, _speedRotation * Time.fixedDeltaTime, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
