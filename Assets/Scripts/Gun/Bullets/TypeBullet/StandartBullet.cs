using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : Bullet
{
    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage((int)_damage);
            PullOutOfGun();
        }
    }
}
