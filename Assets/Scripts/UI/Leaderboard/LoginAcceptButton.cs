using UnityEngine;
using Agava.YandexGames;

public class LoginAcceptButton : MonoBehaviour
{
    [SerializeField] private LoginPanel _loginPanel;
    [SerializeField] private GameObject _infoPanel;

    public void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;

        _infoPanel.gameObject.SetActive(true);
        _loginPanel.gameObject.SetActive(false);
    }
}
