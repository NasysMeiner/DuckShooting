using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private LeaderboardButton _leaderboardButton;
    [SerializeField] private GameObject _shopButton;

    private void OnEnable()
    {
        _settingsButton.SetActive(false);
        _playButton.SetActive(false);
        _leaderboardButton.gameObject.SetActive(false);
        _shopButton.SetActive(false);
    }

    private void OnDisable()
    {        
        _settingsButton.SetActive(true);
        _playButton.SetActive(true);
        _leaderboardButton.gameObject.SetActive(true);
        _shopButton.SetActive(true);
    }
}
