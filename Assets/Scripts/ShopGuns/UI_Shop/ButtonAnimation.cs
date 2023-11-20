using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAnimation : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected Image _pressedButton;
    [SerializeField] protected TMP_Text _textButton;
    [SerializeField] protected Color _enable;
    [SerializeField] protected Color _disable;

    private bool _isActive = false;

    public bool IsActive => _isActive;

    public virtual void Press()
    {
        _button.interactable = false;
        _isActive = true;
        _pressedButton.enabled = true;
        _textButton.color = _enable;
    }

    public virtual void Off()
    {
        _button.interactable = true;
        _isActive = false;
        _pressedButton.enabled = false;
        _textButton.color = _disable;
    }
}
