using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    public void Pause()
    {
        _pausePanel.SetActive(true);
    }
}
