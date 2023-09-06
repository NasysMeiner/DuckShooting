using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartEnemy : Enemy
{
    public override void Init(float healthPoint, float damage)
    {
        _healthPoint = healthPoint;
        _damage = damage;
    }
}
