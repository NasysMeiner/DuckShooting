using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerGuns))]
public class PlayerCompositeRoot : CompositeRoot
{
    [Header("Player components")]
    [SerializeField] private List<IconSlot> _iconSlots;

    [Header("Other components")]
    [SerializeField] private ArsenalPlayer _arsenalPlayer;
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] private SpawnerGuns _spawnerGuns;

    public override void Compose()
    {
        _shopGun.InitShopGun();
        _spawnerGuns.Init(_shopGun);
        _arsenalPlayer.InitArsenal(_iconSlots);
    }
}


