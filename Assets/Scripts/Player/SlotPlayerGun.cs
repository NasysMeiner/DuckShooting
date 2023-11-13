using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPlayerGun
{
    private Gun _gun;
    private Bullet _bullet;
    private IconSlot _iconSlot;
    private Transform _transformPoint;
    private bool _isActiveSlot = false;

    public Gun Gun => _gun;
    public bool IsActiveSlot => _isActiveSlot;
    public Transform TransformPoint => _transformPoint;

    public SlotPlayerGun(Gun gun, Bullet bullet, IconSlot iconSlot, Transform transformPoint)
    {
        _gun = gun;
        _bullet = bullet;
        _iconSlot = iconSlot;
        _transformPoint = transformPoint;

        UpdatePosition();
    }

    public void ActiveSlot()
    {
        _isActiveSlot = true;
        _iconSlot.ActiveSlot();
    }

    public void InactiveSlot()
    {
        _isActiveSlot = false;
        _iconSlot.InactiveSlot();
    }

    public void ChangeGun(Gun gun)
    {
        _gun.StopFire();
        _gun = gun;
        _bullet = _gun.AmmoBag.StandartBullet;
        ChangePointPosition();
    }

    public void ChangePointPosition(Transform newPoint = null)
    {
        if(newPoint != null)
            _transformPoint = newPoint;

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        _gun.transform.position = _transformPoint.position;
    }
}
