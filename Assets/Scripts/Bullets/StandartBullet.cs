using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : Bullet
{
    public override void Init(float speed, float damage)
    {
        _speed = speed;
        _damage = damage;
    }

    public override int MakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void SetVelocity()
    {
        //GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.up * _speed;
    }
}
