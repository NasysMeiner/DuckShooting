using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour, IBullet
{
    protected float _speed = 3f;
    protected float _damage = 1f;
    protected bool _isInCannon = false;
    protected Rigidbody _rigidbody;

    public bool IsInCannon => _isInCannon;

    public abstract void Init(float speed, float damage);
    public abstract int MakeDamage();
    public abstract void SetVelocity();

    public void SetInGun()
    {
        _isInCannon = true;
    }

    public void PullOutOfGun()
    {
        _rigidbody.velocity = Vector3.zero;
        _isInCannon = false;
    }
}
