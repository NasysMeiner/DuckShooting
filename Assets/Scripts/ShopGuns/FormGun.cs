using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormGunOld
{
    [SerializeField] private Sprite _iconGun;
    [SerializeField] private string _name;
    [SerializeField] private Gun _prefabGun;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _timeShoot;

    public Gun PrefabGun => _prefabGun;
    public Bullet Bullet => _bullet;
    public float TimeShoot => _timeShoot;
    public string Name => _name;
    public Sprite IconGun => _iconGun;
}
