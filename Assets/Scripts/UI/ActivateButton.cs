using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _allActiveButton;
    [SerializeField] private GameObject _activeButton;
    [SerializeField] private GameObject _panel;

    private void AllActive()
    {
        for (int i = 0; i < _allActiveButton.Length; i++)
        {
            _allActiveButton[i].SetActive(false);
        }
    }

    public void OnClick()
    {
        AllActive();
        _activeButton.SetActive(true);
        _panel.SetActive(true);
    }
}
