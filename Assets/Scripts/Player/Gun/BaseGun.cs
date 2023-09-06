using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour, IGun
{
    [SerializeField] protected BulletStore _bulletStore;
    [SerializeField] protected ShotPoint _shotPoint;
    [SerializeField] protected float _timeShot = 1;

    protected bool _isStart = false;

    public void StartFire()
    {
        if(_isStart == false)
        {
            _isStart = true;
            StartCoroutine(TakeFire());
        }
    }

    public void StopFire()
    {
        if(_isStart == false)
        {
            _isStart = false;
            StopCoroutine(TakeFire());
        } 
    }

    public Bullet SearchBullet()
    {
        return _bulletStore.SearchFreeBullet();
    }

    public virtual Bullet SetTypeDamage(Bullet bullet)
    {
        return bullet;
    }

    private void TakeShot()
    {
        Bullet bullet = SearchBullet();

        if (bullet != null)
        {
            bullet.SetInGun();
            bullet = SetTypeDamage(bullet);
            bullet.transform.position = _shotPoint.transform.position;
            bullet.SetVelocity();
        }     
    }

    private IEnumerator TakeFire()
    {
        while (true)
        {
            TakeShot();

            yield return new WaitForSeconds(_timeShot);
        }  
    }
}
