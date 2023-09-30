using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private GameObject _confirmationPanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Image _dimed;

    private void OnEnable()
    {
        Time.timeScale = 0;
        _dimed.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
        _panel.localPosition = new Vector2(0, -Screen.height);
        _panel.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutExpo).SetUpdate(UpdateType.Normal, true);
    }

    public void ClosePanel()
    {
        _panel.DOLocalMoveY(-Screen.height, 0.5f).SetEase(Ease.InExpo).OnComplete(Complete).SetUpdate(UpdateType.Normal, true);
    }

    public void Confirmation()
    {
        _confirmationPanel.SetActive(true);
    }

    private void Complete()
    {
        Time.timeScale = 1;
        _panel.gameObject.SetActive(false);
        _dimed.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
    }
}
