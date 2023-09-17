using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartEnemy : Enemy
{
    public override void FindWay(string _nameOfSpawnpoints)
    {
        _nameOfSpawnpoints = "Spawnpoint";
        _waypoints = GameObject.FindGameObjectsWithTag(_nameOfSpawnpoints);
    }

    public override void Init(int healthPoint, float damage, GameObject[] waypoints)
    {
        _healthPoint = healthPoint;
        _damage = damage;
        _waypoints = waypoints;
    }
}