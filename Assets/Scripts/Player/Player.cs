using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IGun _currentGun;

    public void TakeDamage(float damage)
    {
        Debug.Log("Есть пробитие!");
        //_healthPoint -= damage;
    }
}
