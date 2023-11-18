using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [Header("TypeBullet")]
    [SerializeField] private List<Form> _bullets;

    private AmmoBag _ammoBag;

    public void InitSpawnBullet(AmmoBag ammoBag)
    {
        _ammoBag = ammoBag;
        SpawnBullet();
    }

    private void SpawnBullet()
    {
        foreach(Form form in _bullets)
        {
            for(int i = 0; i < form.Number; i++)
            {
                Bullet newBullet = Instantiate(form.Prefab, transform.localPosition, Quaternion.identity);
                newBullet.Init(form.Speed, form.Damage, _ammoBag);
                newBullet.transform.SetParent(transform);
                _ammoBag.AddBullet(newBullet);
            }
        }
    }
}

[System.Serializable]
public class Form
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _number;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public Bullet Prefab => _prefab;
    public int Number => _number;
    public float Speed => _speed;
    public float Damage => _damage;
}
