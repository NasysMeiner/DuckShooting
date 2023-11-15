using System.Collections.Generic;
using UnityEngine;

public class EnemyBag : MonoBehaviour
{
    private List<Enemy> _enemys = new List<Enemy>();
    private int _currentEnemy = 0;

    public void AddEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        enemy.gameObject.SetActive(false);
        _enemys.Add(enemy);
    }

    public void ActivateEnemy()
    {
        if (_currentEnemy < _enemys.Count)
        {
            _enemys[_currentEnemy].gameObject.SetActive(true);
            _currentEnemy++;
        }
    }
}
