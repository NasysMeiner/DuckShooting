using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GarageOfHumans _garage;

    private void Awake()
    {
        _playerData.Init();
        StartCoroutine(WaitForLoadPlayerData());
    }

    private void OnDestroy()
    {
        _playerData.SaveData();
    }

    private IEnumerator WaitForLoadPlayerData()
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        while (_playerData.IsDataLoaded == false)
        {
            yield return waitForEndOfFrame;
        }

        ApplyGameSettings();
    }

    private void ApplyGameSettings()
    {
        _garage.Init();
    }
}
