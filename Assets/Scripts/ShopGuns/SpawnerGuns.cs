using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGuns : MonoBehaviour
{
    [SerializeField] private List<FormGun> _formsGun;

    private ShopGun _shopGun;
    private AmmoBag _ammoBag;

    public void Init(ShopGun shopGun, AmmoBag ammoBag)
    {
        _shopGun = shopGun;
        _ammoBag = ammoBag;
        SpawnAllGun();
    }

    private void SpawnAllGun()
    {
        foreach(FormGun formGun in _formsGun)
        {
            Gun newGun = Instantiate(formGun.PrefabGun, transform);
            newGun.Init(formGun.TimeShoot, _ammoBag, formGun.EquipmentTime, formGun.StoreSize, formGun.RechargeTime);
            _shopGun.PlaceInCell(newGun, formGun);
        }
    }
}

[System.Serializable]
public class FormGun
{
    [SerializeField] private Sprite _iconGun;
    [SerializeField] private string _name;
    [SerializeField] private Gun _prefabGun;
    [SerializeField] private float _timeShoot;
    [SerializeField] private int _storeSize;
    [SerializeField] private float _equipmentTime;
    [SerializeField] private float _rechargeTime;

    public Gun PrefabGun => _prefabGun;
    public float TimeShoot => _timeShoot;
    public string Name => _name;
    public Sprite IconGun => _iconGun;
    public float EquipmentTime => _equipmentTime;
    public int StoreSize => _storeSize;
    public float RechargeTime => _rechargeTime;
}
