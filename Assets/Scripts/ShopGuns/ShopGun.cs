using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopGun : MonoBehaviour
{
    [Header("Init Components")]
    [SerializeField] private ArsenalPlayer _arsenalPlayer;
    [SerializeField] private ShopCellGun _prefabUIShopCell;

    [Header("UI gun slot: transform, icons")]
    [SerializeField] private List<SlotGun> _slots;
    [SerializeField] private Transform _transformUIShop;

    private List<ShopCellGun> _cellGuns = new List<ShopCellGun>();

    private int _currentSlotIndex = 0;

    public event UnityAction<TypeBullet> ChangeCurrentSlotIndex;

    public int CurrentSlotIndex => _currentSlotIndex;

    private void OnDisable()
    {
        foreach (ShopCellGun cellGun in _cellGuns)
        {
            cellGun.ChangeGun -= ChangeGunPlayer;
        }
    }

    public void InitShopGun()
    {
        ChangeActiveSlot();
    }

    public void ChangeActiveSlot(int newIndex = 0)
    {
        if (_slots == null)
            throw new NotImplementedException("null slot icon gun");

        if (newIndex != _currentSlotIndex)
            _slots[_currentSlotIndex].Off();

        _slots[newIndex].Press();
        _currentSlotIndex = newIndex;
        ChangeCurrentSlotIndex?.Invoke(_arsenalPlayer.GetTypeBullet(_currentSlotIndex));
    }

    public void PlaceInCell(Gun gun, FormGun formGun)
    {
        ShopCellGun cellGun = Instantiate(_prefabUIShopCell, _transformUIShop);
        cellGun.Init(gun, formGun, false);
        _cellGuns.Add(cellGun);
        cellGun.ChangeGun += ChangeGunPlayer;
    }

    public SlotPlayerGun SetGunPlayer(IconSlot iconSlot, Transform point)
    {
        foreach (ShopCellGun cellShop in _cellGuns)
        {
            if (cellShop.IsEquip == false)
            {
                var newSlot = new SlotPlayerGun(cellShop.Gun, TypeBullet.Standart, iconSlot, point);
                cellShop.EquipGun();
                return newSlot;
            }
        }

        return null;
    }

    public void UpdateData()
    {
        ChangeCurrentSlotIndex?.Invoke(_arsenalPlayer.GetTypeBullet(_currentSlotIndex));
    }

    private void ChangeGunPlayer(Gun gun)
    {
        _arsenalPlayer.SetShopGunSlot(_currentSlotIndex, gun, out Gun oldGun);

        if (oldGun != null)
        {
            foreach (ShopCellGun shopCellGun in _cellGuns)
            {
                if (shopCellGun.Gun == oldGun)
                {
                    shopCellGun.UnequipGun();
                    ReturnGunInShop(shopCellGun);

                    break;
                }
            }
        }
    }

    private void ReturnGunInShop(ShopCellGun shopCellGun)
    {
        shopCellGun.Gun.transform.SetParent(transform);
        shopCellGun.Gun.transform.position = transform.position;
    }
}
