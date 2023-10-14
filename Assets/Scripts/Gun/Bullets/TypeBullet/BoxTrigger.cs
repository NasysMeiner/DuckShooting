using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;

public class BoxTrigger : MonoBehaviour
{
    private List<Enemy> _enemyList = new List<Enemy>();

    public event UnityAction<Enemy> ChangeEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if(_enemyList.Contains(enemy) == false)
            {
                _enemyList.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_enemyList.Contains(enemy))
            {
                ChangeEnemy?.Invoke(enemy);
                _enemyList.Remove(enemy);
            }
        }
    }

    public Enemy SearchTarget(Enemy enemy)
    {
        int random = Random.Range(0, _enemyList.Count);
        Enemy newTarget = _enemyList[random];

        if (newTarget != enemy)
            return newTarget;
        else
            return SearchTarget(enemy);
    }
}
