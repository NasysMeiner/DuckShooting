using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementTest : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private NavMeshAgent _agent;
    private int _waypointsIndex;
    private Vector3 _target;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    private void UpdateDestination()
    {
        _target = _waypoints[_waypointsIndex].position;
        _agent.SetDestination(_target);
    }

    private void IterateWaypointIndex()
    {
        _waypointsIndex++;

        if(_waypointsIndex == _waypoints.Length)
        {
            _waypointsIndex = 0;
        }
    }
}
