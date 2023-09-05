using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour, IBullet
{
    protected float _speed = 3f;
    protected float _damage = 1f;

    public abstract void Init(float speed, float damage);

    public abstract int MakeDamage();
    public abstract void SetVelocity();
}
