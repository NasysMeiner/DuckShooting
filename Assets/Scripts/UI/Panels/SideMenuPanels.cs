using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideMenuPanels : MonoBehaviour
{
    [SerializeField] private Button[] _anotherButtons; 
    [SerializeField] private Transform _panel;
    [SerializeField] private GameObject _activeButton;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;

    private void OnEnable()
    {
        DisableButtons();
        _panel.DOLocalMove(_endPosition, 0.3f).SetUpdate(UpdateType.Normal, true);
        _panel.DOScale(1f, 0.4f).SetUpdate(UpdateType.Normal, true);
    }

    private void Close()
    {
        _panel.gameObject.SetActive(false);
        _activeButton.SetActive(false);
        EnableButtons();
    }

    private void DisableButtons()
    {
        for (int i = 0; i < _anotherButtons.Length; i++)
        {
            _anotherButtons[i].interactable = false;
        }
    }
    private void EnableButtons()
    {
        for (int i = 0; i < _anotherButtons.Length; i++)
        {
            _anotherButtons[i].interactable = true;
        }
    }

    public void Cancel()
    {
        _panel.DOLocalMove(_startPosition, 0.4f).SetUpdate(UpdateType.Normal, true).OnComplete(Close);
        _panel.DOScale(0.1f, 0.3f).SetUpdate(UpdateType.Normal, true);
    }
}
