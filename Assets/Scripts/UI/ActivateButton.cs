using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    [SerializeField] private GameObject _activeButton;
    [SerializeField] private GameObject _panel;

    public void OnClick()
    {
        _activeButton.SetActive(true);
        _panel.SetActive(true);
    }
}
