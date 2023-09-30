using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGun : MonoBehaviour
{
    [SerializeField] private StockBullet _stockBullet;
    [SerializeField] private ArsenalPlayer _arsenalPlayer;
    [SerializeField] private UIShopCell _prefabUIShopCell;
    [SerializeField] private Transform _transformUIShop;

    private List<CellGun> _guns = new List<CellGun>();
    private int _currentSlotChange = 0;

    public StockBullet StockBullet => _stockBullet;

    private void OnDisable()
    {
        foreach (CellGun cellGun in _guns)
        {
            cellGun.UIShopCell.ChangeGun -= OnChangeGun;
        }
    }

    public void PlaceInCell(Gun gun)
    {
        UIShopCell NewUIShopCell = Instantiate(_prefabUIShopCell, _transformUIShop);
        NewUIShopCell.Init(gun);
        NewUIShopCell.ChangeGun += OnChangeGun;

        CellGun cellGun = new CellGun(gun, NewUIShopCell);
        _guns.Add(cellGun);

        SetGunPlayer(cellGun.Gun);
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
        foreach(CellGun cellGun in _guns)
        {
            if(cellGun.Gun == gun)
            {
                cellGun.Gun.Deactivate();
                cellGun.Gun.StopFire();
                cellGun.Gun.transform.position = transform.position;
                cellGun.Gun.transform.SetParent(transform);
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
