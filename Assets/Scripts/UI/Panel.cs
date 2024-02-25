using UnityEngine;

public class Panel : MonoBehaviour
{
    private bool _isOpen = false;

    public bool IsOpen => _isOpen;

    public void Open()
    {
        _isOpen = true;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        _isOpen = false;
        gameObject.SetActive(false);
    }
}