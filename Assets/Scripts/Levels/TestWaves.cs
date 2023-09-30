using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestWaves : MonoBehaviour
{
    private WaveSpawner _waveSpawner;
    public event UnityAction<bool> IsConfirmAction;

    private void Awake()
    {
        _waveSpawner = GameObject.Find("WaveController").GetComponent<WaveSpawner>();
        
    }

    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesLeft == 0)
            _waveSpawner.LaunchWave();
    }
}
