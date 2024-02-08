using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PriceList", menuName = "Price List", order = 52)]
public class PriceList : ScriptableObject
{
    [SerializeField] private List<Price> _prices;

    public List<Price> Prices => _prices;
}

[System.Serializable]
public class Price
{
    [SerializeField] private PlayerCharacterName _playerCharacterName;
    [SerializeField] private string _nameKey;
    [SerializeField] private int cost;
    [SerializeField] private bool _isBuyForAd;
    [SerializeField] private Sprite _image;

    public PlayerCharacterName PlayerCharacterName => _playerCharacterName;
    public string NameKey => _nameKey;
    public int Cost => cost;
    public bool IsBuyForAd => _isBuyForAd;
    public Sprite Image => _image;
}