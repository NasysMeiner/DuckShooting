using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGuns : MonoBehaviour
{
    [SerializeField] protected List<FormGun> _formsGun;

    private ShopGun _shopGun;

    public void Init(ShopGun shopGun)
    {
        _shopGun = shopGun;
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

[System.Serializable]
public class FormGun
{
    [SerializeField] private Gun _prefabGun;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _timeShoot;

    public Gun PrefabGun => _prefabGun;
    public Bullet Bullet => _bullet;
    public float TimeShoot => _timeShoot;
}
