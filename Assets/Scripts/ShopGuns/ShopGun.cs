using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGun : MonoBehaviour
{
    [SerializeField] private StockBullet _stockBullet;
    [SerializeField] private ArsenalPlayer _arsenalPlayer;

    private List<CellGun> _guns = new List<CellGun>();

    public StockBullet StockBullet => _stockBullet;

    public void PlaceInCell(Gun gun)
    {
        CellGun cellGun = new CellGun(gun);
        _guns.Add(cellGun);

        SetGunPlayer(cellGun.Gun);
    }

    public void SetGunPlayer(Gun gun)
    {
        if (_arsenalPlayer.MeinSlotGun == null)
            _arsenalPlayer.SetMeinSlotGun(gun);
        else if (_arsenalPlayer.ExtraSlotGun == null)
            _arsenalPlayer.SetExtraSlotGun(gun);
    }
}
