using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] protected TypeBullet _typeBullet = TypeBullet.Standart;

    private bool _isInCannon = false;

    protected float _standartDamage = 1f;
    protected float _speed = 3f;
    protected float _damage;
    protected Rigidbody _rigidbody;

    protected AmmoBag _ammoBag;

    public bool IsInCannon => _isInCannon;
    public TypeBullet TypeBullet => _typeBullet;
    float IBullet.Damage => _damage;

    public virtual void MakeDamage(float damage)
    {
        _damage += damage;
    }
    public virtual void SetVelocity()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
        _rigidbody.velocity = Vector3.up * _speed;
    }

    public virtual void Init(float speed, float damage, AmmoBag ammoBag)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = speed;
        _damage = damage;
        _ammoBag = ammoBag;
        _standartDamage = damage;
    }

    public void SetInGun()
    {
        _isInCannon = true;
    }

    public void PullOutOfGun()
    {
        if(_isInCannon)
        {
            _ammoBag.AddBullet(this);
            _damage = _standartDamage;
            _rigidbody.velocity = Vector3.zero;
            _isInCannon = false;
        }
    }
}
