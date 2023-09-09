using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : Bullet
{
    public override void Init(float speed, float damage)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = speed;
        _damage = damage;
    }

    public override int MakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void SetVelocity()
    {
        _rigidbody.velocity = Vector3.up * _speed;
    }
}
