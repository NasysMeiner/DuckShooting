using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _shot;
    [SerializeField] private Transform _shotSpawn;
    [SerializeField] private float _reloadTimer = 1f;

    private void Start()
    {
        StartCoroutine(Shot());
    }

    //private void Update()
    //{
    //    if (_reloadTimer > 0) 
    //        _reloadTimer -= Time.deltaTime;

    //    if (_reloadTimer <= 0)
    //    {
    //        Instantiate(_shot, _shotSpawn.position, _shotSpawn.rotation);
    //        _reloadTimer = 2f;
    //    }
    //}

    private IEnumerator Shot()
    {
        while (true)
        {
            Instantiate(_shot, _shotSpawn.position, _shotSpawn.rotation);
            yield return new WaitForSeconds(_reloadTimer);
        }
    }
}
