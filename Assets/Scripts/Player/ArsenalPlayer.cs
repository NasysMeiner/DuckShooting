using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenalPlayer : MonoBehaviour
{
    [SerializeField] private Transform _pointMeinPositionGun;
    [SerializeField] private Transform _pointExtraPositionGun;

    private Gun _meinSlotGun = null;
    private Gun _extraSlotGun = null;

    public Gun MeinSlotGun => _meinSlotGun;
    public Gun ExtraSlotGun => _extraSlotGun;

    public void SetMeinSlotGun(Gun gun)
    {
        _meinSlotGun = gun;
        gun.transform.position = _pointMeinPositionGun.position + (gun.transform.position - gun.PointPosition.position);
        gun.transform.SetParent(transform);
    }

    public void SetExtraSlotGun(Gun gun)
    {
        _extraSlotGun = gun;
        gun.transform.position = _pointExtraPositionGun.position + (gun.transform.position - gun.PointPosition.position);
        gun.transform.SetParent(transform);
    }

    public void StartFire()
    {
        if(_meinSlotGun != null)
            _meinSlotGun.StartFire();
    }

    public void ChangeGun()
    {
        if(_meinSlotGun != null && _extraSlotGun != null)
        {
            ChangePositionGun();
            Gun temporaryGun = _meinSlotGun;
            _meinSlotGun.StopFire();
            _meinSlotGun = _extraSlotGun;
            _extraSlotGun = temporaryGun;
            _meinSlotGun.StartFire();
        }
    }

    private void ChangePositionGun()
    {
        _meinSlotGun.transform.position = _pointExtraPositionGun.position + (_meinSlotGun.transform.position - _meinSlotGun.PointPosition.position);
        _extraSlotGun.transform.position = _pointMeinPositionGun.position + (_extraSlotGun.transform.position - _extraSlotGun.PointPosition.position);
    }
}
