using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArsenalPlayer : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots = new List<Slot>();
    [SerializeField] private Button _changeGunButton;
    [SerializeField] private float _buttonRollbackTime = 1f;

    public int SlotCount => _slots.Count;

    public void SetGunSlot(int slot, Gun gun, out Gun oldGun)
    {
        oldGun = _slots[slot].SlotGun;
        _slots[slot].SetGun(gun);
        SetParent(_slots[slot].SlotGun);
    }

    public int SearchNullSlots()
    {
        for(int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].SlotGun == null)
                return i;
        }

        return -1;
    }

    public void SetParent(Gun gun)
    {
        gun.transform.SetParent(transform);
    }

    public void StartFire()
    {
        if(_slots[0].SlotGun != null)
            _slots[0].SlotGun.StartFire();
    }

    public void StopFire()
    {
        if(_slots[0].SlotGun != null)
            _slots[0].SlotGun.StopFire();
    }

    public void ChangeGun()
    {
        StartCoroutine(DisableButton());

        StopFire();

        for (int i = 0; i < _slots.Count - 1; i++)
        {
            Gun timeGun = _slots[i].SlotGun;
            _slots[i].SetGun(_slots[i + 1].SlotGun);
            _slots[i + 1].SetGun(timeGun);
        }

        StartFire();
    }

    private IEnumerator DisableButton()
    {
        _changeGunButton.interactable = false;

        yield return new WaitForSeconds(_buttonRollbackTime);

        _changeGunButton.interactable = true;

        StopCoroutine(DisableButton());
    }
}

[System.Serializable]
public class Slot
{
    [SerializeField] private Transform _positionSlot;
    
    private Gun _slotGun;

    public Gun SlotGun => _slotGun;

    public void SetGun(Gun gun)
    {
        _slotGun = gun;
        _slotGun.transform.position = _positionSlot.position + (_slotGun.transform.position - _slotGun.PointPosition.position);
    }
}