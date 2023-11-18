using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private ShotPoint _shotPoint;
    [SerializeField] private Transform _pointPosition;

    private TypeBullet _typeBullet;
    private float _timeShot = 1;
    private float _damage = 1;
    private int _storeSize = 10;
    private float _equipmentTime;
    private float _rechargeTime;

    private AmmoBag _ammoBag;

    private bool _isStart = false;
    private Queue<Bullet> _currentClip = null;
    private int _millisekundy = 1000;

    public float EquipmentTime => _equipmentTime;

    private void OnApplicationQuit()
    {
        _isStart = false;
    }

    public void Init(float timeShot, AmmoBag ammoBag, float equipmentTime, int storeSize, float rechargeTime)
    {
        _timeShot = timeShot;
        _ammoBag = ammoBag;
        _storeSize = storeSize;
        _equipmentTime = equipmentTime;
        _rechargeTime = rechargeTime;
    }

    public void StartFire()
    {
        if (_isStart == false)
        {
            _isStart = true;
            TakeFire();
        }
    }

    public void StopFire()
    {
        if (_isStart == true)
        {
            _isStart = false;

            while (_currentClip.Count > 0)
            {
                Bullet bullet = _currentClip.Dequeue();
                bullet.PullOutOfGun();
            }
        }
    }

    public Queue<Bullet> SearchNewClip()
    {
        return _ammoBag.ReloadClip(_typeBullet, _storeSize);
    }

    public virtual Bullet SetTypeDamage(Bullet bullet)
    {
        return bullet;
    }

    public void ChangeTypeBullet(TypeBullet typeBullet)
    {
        _typeBullet = typeBullet;
    }

    private void TakeShot()
    {
        if (_currentClip == null || _currentClip.Count <= 0)
            _currentClip = SearchNewClip();

        if (_currentClip.Count > 0)
        {
            Bullet bullet = _currentClip.Dequeue();

            if (bullet != null)
            {
                bullet.SetInGun();
                bullet = SetTypeDamage(bullet);
                bullet.transform.position = _shotPoint.transform.position;
                bullet.SetVelocity();
            }           
        }
    }

    private async void TakeFire()
    {
        while (true)
        {
            if (_isStart == false)
                break;

            TakeShot();

            if (_currentClip.Count <= 0)
                await Task.Delay((int)(_rechargeTime * _millisekundy));
            else
                await Task.Delay((int)(_timeShot * _millisekundy));
        }
    }
}
