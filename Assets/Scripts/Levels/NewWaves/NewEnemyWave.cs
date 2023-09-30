using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyWave : MonoBehaviour
{
    private LevelData _level;
    private List<GameObject> _enemies = new List<GameObject>();
    private int _indexEnemy;
    private int _indexWave;
    private float _count;

    private void Awake()
    {
        _level = Resources.Load<LevelData>($"Levels/Level1");
    }

    public void Generate()
    {
        foreach (var newWave in _level.Waves)
        {
            for (int i = 0; i < newWave.CountInWave; i++)
            {
                var enemy = Instantiate(newWave.EnemyPrefab, transform);
                enemy.SetActive(false);
                _enemies.Add(enemy);
            }
        }
    }

    public void Activate()
    {
        StartCoroutine(EnemyActivate());
    }

    private IEnumerator EnemyActivate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        var count = _level.Waves[_indexWave].CountInWave;

        while (count > 0)
        {
            count--;
            _enemies[_indexEnemy].gameObject.SetActive(true);
            _indexEnemy++;
            yield return wait;
        }

        if (_indexWave < _level.Waves.Count - 1)
        {
            Invoke(nameof(Activate), _level.Waves[_indexWave].WaitAfterWave);
            _indexWave++;
        }
    }
}
