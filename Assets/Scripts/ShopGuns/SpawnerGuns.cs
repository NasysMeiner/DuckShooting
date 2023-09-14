using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGuns : MonoBehaviour
{
    private List<FormGun> _formsGun;
    private ShopGun _shopGun;

    public void Init(ShopGun shopGun, List<FormGun> formsGun)
    {
        _shopGun = shopGun;
        _formsGun = formsGun;
    }

    public void SpawnAllGun()
    {
        foreach(FormGun formGun in _formsGun)
        {
            Gun newGun = Instantiate(formGun.PrefabGun);
            newGun.Init(formGun.Bullet, formGun.TimeShoot, _shopGun.StockBullet);
            _shopGun.PlaceInCell(newGun);
        }
    }
}
