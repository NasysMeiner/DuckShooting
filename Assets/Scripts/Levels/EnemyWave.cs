using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private bool _isOnSpawn = true;
    [SerializeField] private List<Enemys> _enemys;
    [SerializeField] private EnemyBag _enemyBag;
    [SerializeField] private int _waitAfterEnemy;

    private int _millisekundy = 1000;
    private bool _isStart = true;
    private int _currentWave = 0;

    private void Start()
    {
        if (_isOnSpawn)
            SpawnAllEnemy();
    }
    private void SpawnAllEnemy()
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

        SpawnEnemy();
    }

    private async void SpawnEnemy()
    {
        while (true)
        {
            if (_isStart == false)
            {
                break;
            }

            _enemyBag.ActivateEnemy();

            await Task.Delay((int)(_enemys[_currentWave].WaitAfterWave * _millisekundy));
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