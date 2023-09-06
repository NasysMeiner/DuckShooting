using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyList;

    public void SpawnEnemy()
    {
        Instantiate(_enemyList, transform.localPosition, Quaternion.identity);
    }
}
