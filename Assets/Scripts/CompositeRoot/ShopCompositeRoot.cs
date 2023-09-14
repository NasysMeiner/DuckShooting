using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerGuns))]
public class ShopCompositeRoot : CompositeRoot
{
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] private SpawnerGuns _spawnerGuns;

    public override void Compose()
    {
        _spawnerGuns.Init(_shopGun);
        _spawnerGuns.SpawnAllGun();
    }
}


