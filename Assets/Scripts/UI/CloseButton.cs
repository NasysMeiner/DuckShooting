using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Close()
    {
        _panel.SetActive(false);
    }
}
