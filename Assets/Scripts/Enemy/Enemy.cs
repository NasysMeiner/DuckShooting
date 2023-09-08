using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _healthPoint = 1;
    [SerializeField] protected float _damage = 1f;

    protected Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        if(_healthPoint == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void Init(int healthPoint, float damage);
}
