using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _healthPoint = 100;
    [SerializeField] protected float _damage = 1f;
    [SerializeField] protected Slider _healthBar;
    [SerializeField] protected List<GameObject> _waypoints;
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

    public abstract void Init(int healthPoint, float damage, List<GameObject> waypoints);

    private void Movement()
    {
        Vector3 destination = _waypoints[_index].transform.position;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
        transform.position = newPosition;
        float distance = Vector3.Distance(transform.position, destination);

        if (distance <= 0.05)
        {
            if (_index < _waypoints.Count - 1)
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