using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private ShotPoint _shotPoint;
    [SerializeField] private Transform _pointPosition;  

    private bool _isStart = false;
    private Bullet _bullet;
    private float _timeShot = 1;
    private StockBullet _stockBullet;

    public Bullet Bullet => _bullet;
    public Transform PointPosition => _pointPosition;

    public void Init(Bullet bullet, float timeShot, StockBullet stockBullet)
    {
        _bullet = bullet;
        _timeShot = timeShot;
        _stockBullet = stockBullet;
    }

    public void SetTypeBullet(Bullet bullet)
    {
        _bullet = bullet;
    }

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
        if(_isStart == true)
        {
            _isStart = false;
            StopCoroutine(TakeFire());
        } 
    }

    public Bullet SearchBullet()
    {
        return _stockBullet.SearchFreeBullet();
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
        bool isWork = true;

        while (isWork)
        {
            if(_isStart == false)
            {
                break;
            }    

            TakeShot();

            yield return new WaitForSeconds(_timeShot);
        }  
    }
}
