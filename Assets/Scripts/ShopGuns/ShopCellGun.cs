using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCellGun
{
    private Gun _gun;
    private bool _isEquip = false;
    private bool _isFire = false;
    private UIShopCell _shopCell;

    public Gun Gun => _gun;
    public bool IsEquip => _isEquip;
    public bool IsFire => _isFire;
    public UIShopCell ShopCell => _shopCell;

    public ShopCellGun(Gun gun, bool isActive, UIShopCell shopCell)
    {
        _gun = gun;
        _isEquip = isActive;
        _shopCell = shopCell;
    }

    public void EquipGun()
    {
        _isEquip = true;
    }
}
