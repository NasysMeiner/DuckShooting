using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Init(float healthPoint, float damage, Path path)
    {
        _healthPoint = healthPoint;
        _damage = damage;
        _path = path;
    }
}
