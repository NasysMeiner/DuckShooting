using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _healthPoint = 100;
    [SerializeField] protected float _damage = 1f;
    [SerializeField] protected Slider _healthBar;
    [SerializeField] protected Path _path;
    [SerializeField] protected float _speed = 2;
    [SerializeField] protected bool IsOnActive = false;

    protected int _index;
    protected EnemyBag _enemyBag;

    private void Update()
    {
        Movement();

        if(_healthPoint == 0)
        {
            IsOnActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            IsOnActive = true;
        }

        _healthBar.value = _healthPoint;
    }

    public virtual void TakeDamage(float damage)
    {
        _healthPoint -= damage;
    }

    public virtual void Init(float healthPoint, float damage, float speed, Path path, EnemyBag enemyBag)
    {
        _healthPoint = healthPoint;
        _damage = damage;
        _speed = speed;
        _path = path;
        _enemyBag = enemyBag;

    }

    private void Movement()
    {
        Vector3 destination = _path.Points[_index];
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, _speed * Time.fixedDeltaTime);

        transform.Translate((destination - transform.position).normalized * _speed * Time.deltaTime, Space.World);

        //transform.position = newPosition;

        //Vector3 offset = (destination - _rigidbody.transform.position).normalized * _speed;
        //_rigidbody.MovePosition(_rigidbody.position + offset);
        float distance = Vector3.Distance(transform.position, destination);

        Quaternion rotation = Quaternion.LookRotation(destination);
        transform.rotation = rotation;

        if (distance <= 0.05)
        {
            if (_index < _path.Points.Count - 1)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }
        }
    }
}