using UnityEngine;

public class CameraWindow : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 0.0001f;
    [SerializeField] private float _minusSpeed = 0.0001f;

    private Movement _player;
    private bool _isInside = true;
    private bool _isMovementCamera = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Movement player))
        {
            _player = player;
            _isInside = false;
            _isMovementCamera = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BorderPlayer player))
            _isInside = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_isMovementCamera)
        {
            float speed = _startSpeed;

            if (transform != null)
                transform.position = Vector3.Lerp(transform.position, _player.transform.position, speed);

            if (_isInside)
                speed -= _minusSpeed;

            if (speed <= 0)
                _isMovementCamera = false;
        }
    }
}
