using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    protected float _healthPoint = 5f;
    protected float _damage = 1f;
    protected Rigidbody _rigidbody;

    public abstract void Init(float _healthPoint, float damage);
}
