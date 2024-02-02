using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _iconCheck;
    [SerializeField] private GameObject _iconLock;
    [SerializeField] private GameObject _adIcon;
    //[SerializeField] private GameObject _coinIcon;
    [SerializeField] private TMP_Text _cost;

    private Price _price;
    private Button _button;

    public event UnityAction<Product, Price> Clicked;

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Init(Price price)
    {
        _price = price;

        _image.sprite = price.Image;

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);

        _iconCheck.SetActive(false); 

        var numberOfOperationBeforeBuy = PlayerData.Instance.ConditionsForCharacters[price.PlayerCharacterName];

        if (numberOfOperationBeforeBuy == 0)
        {
            Unlock();
        }
        else if (price.IsBuyForAd)
        {
            _adIcon.SetActive(price.IsBuyForAd);
            _cost.text = $"{numberOfOperationBeforeBuy} / {price.Cost}";
        }
        else
        {
            _cost.text = price.Cost.ToString();
        }

        if (PlayerData.Instance.SelectedCharacter == (int)price.PlayerCharacterName)
            Select();
    }

    private void OnClick() => Clicked?.Invoke(this, _price);

    public void Unlock()
    {
        _iconLock.SetActive(false);
        _adIcon.SetActive(false);
        //_coinIcon.SetActive(false);
        _cost.text = "";
    }

    public void Select()
    {
        _iconCheck.SetActive(true);
    }

    public void UnSelect()
    {
        _iconCheck.SetActive(false);
    }

    public void UpdateCostText()
    {
        var numberOfOperationBeforeBuy = PlayerData.Instance.ConditionsForCharacters[_price.PlayerCharacterName];
        _cost.text = $"{numberOfOperationBeforeBuy} / {_price.Cost}";
    }
}
