using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBag : MonoBehaviour
{
    private List<Enemy> _enemys = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        //enemy.gameObject.SetActive(false);
        _enemys.Add(enemy);
    }
}
