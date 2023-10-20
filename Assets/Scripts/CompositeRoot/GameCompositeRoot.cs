using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GarageOfHumans _garage;

    public override void Compose()
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
