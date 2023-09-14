using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormGunOld
{
    [SerializeField] private Gun _prefabGun;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _timeShoot;

    public Gun PrefabGun => _prefabGun;
    public Bullet Bullet => _bullet;
    public float TimeShoot => _timeShoot;
}
