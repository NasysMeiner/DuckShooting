using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ConfirmationPanel : MonoBehaviour
{
    [SerializeField] private Transform _confirmationPanel;

    private void OnEnable()
    {
        _confirmationPanel.DOScale(1f, 0.2f).SetUpdate(UpdateType.Normal, true);
    }

    public void Cancel()
    {
        _confirmationPanel.DOScale(0.1f, 0.2f).SetUpdate(UpdateType.Normal, true).OnComplete(Close);
    }

    public void Close()
    {
        _confirmationPanel.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constantes.StrMainMenuScene);
    }
}
