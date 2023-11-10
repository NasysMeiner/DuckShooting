using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerGuns))]
public class PlayerCompositeRoot : CompositeRoot
{
    [Header("Other components")]
    [SerializeField] private ArsenalPlayer _arsenalPlayer;
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] private SpawnerGuns _spawnerGuns;

    [Header("Player components")]
    [SerializeField] private List<IconSlot> _iconSlots;

    public override void Compose()
    {
        _spawnerGuns.Init(_shopGun);
        _arsenalPlayer.InitArsenal(_iconSlots);
    }
}


