using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGun
{
    private Gun _gun;
    private UIShopCell _uiShopCell;

    public Gun Gun => _gun;
    public UIShopCell UIShopCell => _uiShopCell;

    public CellGun(Gun gun, UIShopCell UIShopCell)
    {
        _gun = gun;
        _uiShopCell = UIShopCell;
    }
}
