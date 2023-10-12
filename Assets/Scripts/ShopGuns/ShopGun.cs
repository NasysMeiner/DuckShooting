using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGun : MonoBehaviour
{
    [SerializeField] private AmmoBag _stockBullet;
    [SerializeField] private ArsenalPlayer _arsenalPlayer;
    [SerializeField] private UIShopCell _prefabUIShopCell;
    [SerializeField] private Transform _transformUIShop;

    private List<CellGun> _guns = new List<CellGun>();
    private List<UIShopCell> _cellsShop = new List<UIShopCell>();
    private int _currentSlotChange = 0;

    public AmmoBag StockBullet => _stockBullet;

    private void OnDisable()
    {
        foreach (UIShopCell cellShop in _cellsShop)
        {
            cellShop.ChangeGun -= OnChangeGun;
        }
    }

    public void PlaceInCell(Gun gun)
    {
        UIShopCell cellShop = Instantiate(_prefabUIShopCell, _transformUIShop);
        cellShop.Init(gun);
        cellShop.ChangeGun += OnChangeGun;
        _cellsShop.Add(cellShop);

        SetGunPlayer(gun);
    }

    public void SetActiveSlot(int index)
    {
        _currentSlotChange = index;
    }

    public void SetGunPlayer(Gun gun)
    {
        int index = _arsenalPlayer.SearchNullSlots();

        if (index < 0)
            return;

        gun.Activate();
        _arsenalPlayer.SetGunSlot(index, gun, out Gun oldGun);

        if(oldGun != null)
            ReturnGun(oldGun);
    }

    private void ReturnGun(Gun gun)
    {
        foreach(UIShopCell cellShop in _cellsShop)
        {
            if(cellShop.Gun == gun)
            {
                cellShop.Gun.Deactivate();
                cellShop.Gun.StopFire();
                cellShop.Gun.transform.position = transform.position;
                cellShop.Gun.transform.SetParent(transform);
            }
        }
    }

    private void OnChangeGun(Gun gun)
    {
        _arsenalPlayer.SetGunSlot(_currentSlotChange, gun, out Gun oldGun);
        gun.Activate();

        if (oldGun != null)
            ReturnGun(oldGun);
    }
}
