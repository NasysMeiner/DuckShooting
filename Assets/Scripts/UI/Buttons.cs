using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _settingsPanel;

    public void Play()
    {
        SceneManager.LoadScene(Constantes.StrGame);
    }

    public void Shop()
    {
        _shopPanel.SetActive(true);
    }

    public void Settings()
    {
        _settingsPanel.SetActive(true);
    }
}
