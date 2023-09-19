using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //[SerializeField] private GameObject _settingsButton;
    //[SerializeField] private GameObject _playButton;
    //[SerializeField] private LeaderboardButton _leaderboardButton;
    //[SerializeField] private GameObject _shopButton;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _settingsPanel;

    public void Play()
    {
        SceneManager.LoadScene(Constantes.StrGame);
    }

    public void Shop()
    {
        //_settingsButton.SetActive(false);
        //_shopButton.SetActive(false);
        //_playButton.SetActive(false);
        //_leaderboardButton.gameObject.SetActive(false);
        _shopPanel.SetActive(true);
    }

    public void Settings()
    {
        //_settingsButton.SetActive(false);
        //_playButton.SetActive(false);
        //_leaderboardButton.gameObject.SetActive(false);
        //_shopButton.SetActive(false);
        _settingsPanel.SetActive(true);
    }
}
