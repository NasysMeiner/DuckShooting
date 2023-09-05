using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField] private bool _isOnSpawn = true;
    [SerializeField] private List<Form> _bullets = new List<Form>();

    private void Start()
    {
        if (_isOnSpawn)
            SpawnBullet();
    }

    private void SpawnBullet()
    {
        foreach(Form form in _bullets)
        {
            for(int i = 0; i < form.Number; i++)
            {
                Bullet newBullet = Instantiate(form.Prefab, transform.localPosition, Quaternion.identity);
                newBullet.Init(form.Speed, form.Damage);
                newBullet.transform.SetParent(transform);
                newBullet.transform.position = transform.position;
            }
        }
    }
}

[System.Serializable]
public class Form
{
    [SerializeField] private int _number;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public int Number => _number;
    public Bullet Prefab => _prefab;
    public float Speed => _speed;
    public float Damage => _damage;
}
