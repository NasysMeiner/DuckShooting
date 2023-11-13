using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ArsenalPlayer : MonoBehaviour
{
    [Header("Init Components")]
    [SerializeField] private int _numberSlots = 2;
    [SerializeField] private List<Transform> _slotPosition = new List<Transform>();
    [SerializeField] private ShopGun _shopGun;

    [Header("ArsenalPlayer Components")]
    [SerializeField] private Button _changeGunButton;
    [SerializeField] private float _buttonRollbackTime = 0.5f;

    private int _millisekundy = 1000;
    private List<SlotPlayerGun> _slotsPlayer = new List<SlotPlayerGun>();
    private SlotPlayerGun _currentSlot = null;

    private Queue<SlotPlayerGun> _queueSlot = new Queue<SlotPlayerGun>();

    public void InitArsenal(List<IconSlot> iconSlots)
    {
        if (_numberSlots != iconSlots.Count)
            throw new NotImplementedException("low slots || low icon slots");

        for (int i = 0; i < _numberSlots; i++)
        {      
            SlotPlayerGun newSlot = _shopGun.SetGunPlayer(iconSlots[i], _slotPosition[i]);

            if (newSlot == null)
                throw new NotImplementedException("null slot");

            SetParent(newSlot.Gun);
            _slotsPlayer.Add(newSlot);
            _queueSlot.Enqueue(newSlot); 
        }

        if (_currentSlot == null)
            SetCurrentSlotGun(_queueSlot.Dequeue());
    }

    public void SetShopGunSlot(int indexSlot, Gun newGun, out Gun oldGun)
    {
        if (_slotsPlayer[indexSlot].Gun != null)
            oldGun = _slotsPlayer[indexSlot].Gun;
        else
            oldGun = null;

        _slotsPlayer[indexSlot].ChangeGun(newGun);

        if (_slotsPlayer[indexSlot] == _currentSlot)
            StartFire();
    }

    public void SetParent(Gun gun)
    {
        gun.transform.SetParent(transform);
    }

    public void StartFire()
    {
        _currentSlot.Gun.StartFire();
    }

    public void StopFire()
    {
        _currentSlot.Gun.StopFire();
    }

    public async void ChangeGun()
    {
        _changeGunButton.interactable = false;

        StopFire();

        _currentSlot.InactiveSlot();
        SlotPlayerGun slotPlayerGun = _queueSlot.Dequeue();

        if(slotPlayerGun == null)
            throw new NotImplementedException("null slot");

        Transform oldTransform = _currentSlot.TransformPoint;
        _currentSlot.ChangePointPosition(slotPlayerGun.TransformPoint);
        _queueSlot.Enqueue(_currentSlot);
        _currentSlot = slotPlayerGun;
        _currentSlot.ChangePointPosition(oldTransform);
        _currentSlot.ActiveSlot();

        await Task.Delay((int)(_buttonRollbackTime * _millisekundy));

        await Task.Delay((int)(_currentSlot.Gun.EquipmentTime * _millisekundy));

        StartFire();

        _changeGunButton.interactable = true;
    }

    private void SetCurrentSlotGun(SlotPlayerGun slotPlayerGun)
    {
        _currentSlot = slotPlayerGun;
        _currentSlot.ActiveSlot();
    }
}