using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerGuns))]
public class PlayerCompositeRoot : CompositeRoot
{
    [Header("Player components")]
    [SerializeField] private List<IconSlot> _iconSlots;

    [Header("Init components")]
    [SerializeField] private ArsenalPlayer _arsenalPlayer;
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] private SpawnerGuns _spawnerGuns;
    [SerializeField] private SpawnerBullet _spawnerBullet;

    [Header("Other components")]
    [SerializeField] private AmmoBag _ammoBag;

    public override void Compose()
    {
        _shopGun.InitShopGun();
        _spawnerGuns.Init(_shopGun);
        _arsenalPlayer.InitArsenal(_iconSlots);
        _spawnerBullet.InitSpawnBullet(_ammoBag);
    }
}


