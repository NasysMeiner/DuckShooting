using UnityEngine;

public class LoginDeclineButton : MonoBehaviour
{
    [SerializeField] private LoginPanel _loginPanel;

    public void Decline()
    {
        _loginPanel.gameObject.SetActive(false);
    }
}
