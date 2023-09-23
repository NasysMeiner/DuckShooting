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
        int index = _arsenalPlayer.SearchNullSlots();

        if (index < 0)
            return;

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
                cellGun.Gun.transform.position = transform.position;
                cellGun.Gun.transform.SetParent(transform);
            }
        }
    }
}
