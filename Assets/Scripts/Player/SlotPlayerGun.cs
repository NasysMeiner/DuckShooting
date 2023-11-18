using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPlayerGun
{
    private Gun _gun;
    private TypeBullet _typeBullet;
    private IconSlot _iconSlot;
    private Transform _transformPoint;
    private bool _isActiveSlot = false;

    public Gun Gun => _gun;
    public bool IsActiveSlot => _isActiveSlot;
    public Transform TransformPoint => _transformPoint;

    public SlotPlayerGun(Gun gun, TypeBullet typeBullet, IconSlot iconSlot, Transform transformPoint)
    {
        _gun = gun;
        _typeBullet = typeBullet;
        _iconSlot = iconSlot;
        _transformPoint = transformPoint;

        ChangeTypeBullet(_typeBullet);
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
        _typeBullet = TypeBullet.Standart;
        ChangePointPosition();
    }

    public void ChangePointPosition(Transform newPoint = null)
    {
        if(newPoint != null)
            _transformPoint = newPoint;

        UpdatePosition();
    }

    public void ChangeTypeBullet(TypeBullet typeBullet)
    {
        _typeBullet = typeBullet;
        _gun.ChangeTypeBullet(_typeBullet);
    }

    private void UpdatePosition()
    {
        _gun.transform.position = _transformPoint.position;
    }
}
