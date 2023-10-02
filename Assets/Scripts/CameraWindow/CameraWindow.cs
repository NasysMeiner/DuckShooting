using UnityEngine;

public class CameraWindow : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 0.0001f;
    [SerializeField] private float _minusSpeed = 0.0001f;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _upPoint;
    [SerializeField] private Transform _downPoint;

    private Movement _player;
    private bool _isInside = true;
    private bool _isMovementCamera = false;
    private Vector3 _direction => (new Vector3(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y, _player.transform.position.z - transform.position.z)).normalized;

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
        if(_player != null && transform != null)
            Move(transform.position, _player.transform.position);
    }

    private void Move(Vector3 camera, Vector3 target)
    {
        if (_isMovementCamera)
        {
            float speed = _startSpeed;

            if (_isInside)
                speed -= _minusSpeed;

            if (speed <= 0)
                _isMovementCamera = false;

            CheckPath(speed, out Vector3 direction);

            transform.position = new Vector3(camera.x + (target.x - camera.x) * direction.x, camera.y + (target.y - camera.y) * direction.y, camera.z + (target.z - camera.z) * direction.z);
        }
    }

    private void CheckPath(float speed, out Vector3 direction)
    {
        direction = new Vector3(speed, speed, speed);
 
        if (transform.position.x + 2 * _direction.x * Time.fixedDeltaTime > _rightPoint.position.x || transform.position.x + 2 * _direction.x * Time.fixedDeltaTime < _leftPoint.position.x)
            direction.x = 0;
        
        if(transform.position.y + 2 * _direction.y * Time.fixedDeltaTime > _upPoint.position.y || transform.position.y + 2 * _direction.y * Time.fixedDeltaTime < _downPoint.position.y)
            direction.y = 0;
    }
}
