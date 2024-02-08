using System.Collections;
using TMPro;
using UnityEngine;

public class ShopStart : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ShopTest _shop;
    [SerializeField] private TMP_Text _money;

    private void Awake()
    {
        _playerData.Init();
        StartCoroutine(WaitForLoadPlayerData());
    }

    private void OnDestroy()
    {
        _playerData.SaveData();
        _playerData.MoneyChanged -= InstanceOnMoneyChanged;
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
        _playerData.MoneyChanged += InstanceOnMoneyChanged;
        _shop.Init();
        _money.text = PlayerData.Instance.Money.ToString();
    }

    private void InstanceOnMoneyChanged(int newValue)
    {
        _money.text = PlayerData.Instance.Money.ToString();
    }
}
