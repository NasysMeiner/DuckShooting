using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerGuns))]
public class ShopCompositeRoot : CompositeRoot
{
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] protected List<FormGun> _formsGun;

    public override void Compose()
    {
        SpawnerGuns spawnerGuns = GetComponent<SpawnerGuns>();
        spawnerGuns.Init(_shopGun, _formsGun);
        spawnerGuns.SpawnAllGun();
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
