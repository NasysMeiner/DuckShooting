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

    protected GameObject[] _waypoints;
    protected NavMeshAgent _agent;
    protected int _waypointsIndex;
    protected Vector3 _target;
    protected string _nameOfSpawnpoints;


    private void FixedUpdate()
    {
        if(_healthPoint == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void Init(int healthPoint, float damage, GameObject[] waypoints);
    public abstract void FindWay(string _nameOfSpawnpoints);

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        _healthBar.value = _healthPoint;

        if (Vector3.Distance(transform.position, _target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    private void OnEnable()
    {
        FindWay(_nameOfSpawnpoints);
    }

    private void UpdateDestination()
    {
        _target = _waypoints[_waypointsIndex].transform.position;
        _agent.SetDestination(_target);
    }

    private void IterateWaypointIndex()
    {
        _waypointsIndex++;

        if (_waypointsIndex == _waypoints.Length)
        {
            _waypointsIndex = 0;
        }
    }
}