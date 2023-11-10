using System.Collections.Generic;
using UnityEngine;

public class ShopTest : MonoBehaviour
{
    [SerializeField] private PriceList _priceList;
    [SerializeField] private GameObject _productTemplate;
    [SerializeField] private GameObject _conteiner;
    [SerializeField] private MessageBox _messageBoxWatchAd;
    [SerializeField] private MessageBox _messageBoxBuy;
    [SerializeField] private MessageBox _messageBoxNotEnoughMoney;

    private List<Product> _products = new List<Product>();
    private Product _currentProduct;
    private Price _currentPrice;

    private void OnDestroy()
    {
        foreach (var product in _products)
        {
            product.Clicked -= OnProductClicked;
        }

        _messageBoxBuy.IsConfirmAction -= ProcessingReceivedFromMessageBox;
    }

    public void Init()
    {
        for (int i = 0; i < _priceList.Prices.Count; i++)
        {
            var item = _priceList.Prices[i];

            var product = Instantiate(_productTemplate, _conteiner.transform).GetComponent<Product>();
            product.Init(item);
            product.Clicked += OnProductClicked;

            _products.Add(product);
        }

    }

    private void OnProductClicked(Product productItem, Price price)
    {
        PlayerCharacterName characterType = price.PlayerCharacterName;
        _currentProduct = productItem;
        _currentPrice = price;

        if (PlayerData.Instance.ConditionsForCharacters[characterType] == 0)
            ChangeSelectCar();
        else if (price.IsBuyForAd)
            ShowMessageBoxWatchAd();
        else
            TryBuyCharacter();
    }

    private void ChangeSelectCar()
    {
        foreach (var product in _products)
            product.UnSelect();

        _currentProduct.Select();
        PlayerData.Instance.SelectedCharacter = (int)_currentPrice.PlayerCharacterName;
    }

    private void TryBuyCharacter()
    {
        bool ñanPay = PlayerData.Instance.Money - _currentPrice.Cost >= 0;

        if (ñanPay)
            ShowMessageBoxBuy();
        else
            _messageBoxNotEnoughMoney.ShowMessageBox();
    }

    private void ShowMessageBoxWatchAd()
    {
        _messageBoxWatchAd.ShowMessageBox();
        _messageBoxWatchAd.IsConfirmAction += ProcessingReceivedFromMessageBox;
    }

    private void ShowMessageBoxBuy()
    {
        _messageBoxBuy.ShowMessageBox();
        _messageBoxBuy.IsConfirmAction += ProcessingReceivedFromMessageBox;
    }

    private void ProcessingReceivedFromMessageBox(bool response)
    {
        _messageBoxWatchAd.IsConfirmAction -= ProcessingReceivedFromMessageBox;
        _messageBoxBuy.IsConfirmAction -= ProcessingReceivedFromMessageBox;

        if (response)
        {
            PlayerCharacterName characterType = _currentPrice.PlayerCharacterName;
            PlayerData.Instance.ChangeConditionForCharacter(characterType);

            if (_currentPrice.IsBuyForAd)
            {
                _currentProduct.UpdateCostText();

                if (PlayerData.Instance.ConditionsForCharacters[characterType] == 0)
                {
                    _currentProduct.Unlock();
                }
            }
            else
            {
                PlayerData.Instance.Money -= _currentPrice.Cost;
                _currentProduct.Unlock();
            }
        }
    }
}