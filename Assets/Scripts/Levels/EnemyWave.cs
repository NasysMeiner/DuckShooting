using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private bool _isOnSpawn = true;
    [SerializeField] private List<Enemys> _enemys;
    [SerializeField] private EnemyBag _enemyBag;

    private int _millisekundy = 1000;
    private int _currentWaveIndex;

    private void Start()
    {
        if (_isOnSpawn)
            SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        foreach (Enemys enemy in _enemys)
        {
            for (int i = 0; i < enemy.Number; i++)
            {
                Enemy newEnemy = Instantiate(enemy.Prefab, transform.localPosition, Quaternion.identity);
                newEnemy.Init(enemy.HealthPoint, enemy.Damage, enemy.Speed, enemy.Path, _enemyBag);
                newEnemy.transform.SetParent(transform);
                _enemyBag.AddEnemy(newEnemy);
            }
        }
    }
}

[System.Serializable]
public class Enemys
{
    [SerializeField] private int _number;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _healthPoint;
    [SerializeField] private float _damage;
    [SerializeField] private Path _path;
    [SerializeField] private float _waitAfterWave;


    public int Number => _number;
    public Enemy Prefab => _prefab;
    public Path Path => _path;
    public float Speed => _speed;
    public float HealthPoint => _healthPoint;
    public float Damage => _damage;
    public float WaitAfterWave => _waitAfterWave;
}
