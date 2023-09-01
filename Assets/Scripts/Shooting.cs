using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _shot;
    [SerializeField] private Transform _shotSpawn;
    [SerializeField] private float _fireRate = 3.0f;

    private void Update()
    {
       if (Time.time > _fireRate) 
       {
            Instantiate(_shot, _shotSpawn.position, _shotSpawn.rotation);
       }
    }
}
