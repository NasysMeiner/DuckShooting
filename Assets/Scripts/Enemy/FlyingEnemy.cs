using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public override void Init(int healthPoint, float damage, List<GameObject> waypoints)
    {
        _healthPoint = healthPoint;
        _damage = damage;
        _waypoints = waypoints;
    }
}
