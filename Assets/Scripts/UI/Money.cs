using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text _countOfMoney;

    private void Update()
    {
        _countOfMoney.text = PlayerPrefs.GetInt(Constantes.StrCountMoney).ToString();
    }

}
