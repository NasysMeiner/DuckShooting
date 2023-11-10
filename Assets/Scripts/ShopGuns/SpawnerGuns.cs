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
        SpawnAllGun();
    }

    public void SpawnAllGun()
    {
        foreach(FormGun formGun in _formsGun)
        {
            Gun newGun = Instantiate(formGun.PrefabGun);
            newGun.Init(formGun.TimeShoot, _shopGun.StockBullet, formGun.EquipmentTime);
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
    [SerializeField] private float _equipmentTime;

    public Gun PrefabGun => _prefabGun;
    public float TimeShoot => _timeShoot;
    public string Name => _name;
    public Sprite IconGun => _iconGun;
    public float EquipmentTime => _equipmentTime;
}
