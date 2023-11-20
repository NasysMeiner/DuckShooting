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
    [SerializeField] private AmmoBag _ammoBag;

    //[Header("Other components")]

    public override void Compose()
    {
        _shopGun.InitShopGun();
        _ammoBag.InitAmmoBag(_shopGun, _arsenalPlayer);
        _spawnerGuns.Init(_shopGun, _ammoBag);
        _arsenalPlayer.InitArsenal(_iconSlots);
        _spawnerBullet.InitSpawnBullet(_ammoBag);

        UpdateData();
    }

    private void UpdateData()
    {
        _shopGun.UpdateData();
    }
}


