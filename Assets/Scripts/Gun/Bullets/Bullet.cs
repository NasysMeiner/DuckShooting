using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private TrailRenderer _trail;

    private bool _isInCannon = false;

    protected float _standartDamage = 1f;
    protected float _speed = 3f;
    protected float _damage;
    protected Rigidbody _rigidbody;

    protected AmmoBag _ammoBag;

    public bool IsInCannon => _isInCannon;

    public virtual void MakeDamage(int damage)
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

    private async void ResetTrailRenderer(TrailRenderer tr)
    {
        Debug.Log("2");

        await Task.Delay(100);
        Debug.Log("3");
        _ammoBag.AddBullet(this);


        tr.time = 0.1f;
    }

    public void PullOutOfGun()
    {
        if(_isInCannon == true)
        {
            _trail.time = 0;
            _ammoBag.AddBullet(this);
            _damage = _standartDamage;
            _rigidbody.velocity = Vector3.zero;
            _isInCannon = false;
            Debug.Log("1");
            ResetTrailRenderer(_trail);
            
        }
    }
}
