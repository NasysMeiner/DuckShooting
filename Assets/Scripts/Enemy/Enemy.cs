using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _healthPoint = 100;
    [SerializeField] protected float _damage = 1f;
    [SerializeField] protected Slider _healthBar;
    [SerializeField] protected Path _path;
    [SerializeField] protected float _speed = 2;

    protected int _index;

    private void FixedUpdate()
    {
        Movement();

        if(_healthPoint == 0)
        {
            Destroy(this.gameObject);
        }

        _healthBar.value = _healthPoint;
    }

    public virtual void TakeDamage(float damage)
    {
        _healthPoint -= damage;
    }

    public abstract void Init(float healthPoint, float damage, Path path);

    private void Movement()
    {
        Vector3 destination = _path.Points[_index];
        Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
        transform.position = newPosition;
        float distance = Vector3.Distance(transform.position, destination);

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