using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotGun : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _pressedButton;
    [SerializeField] private TMP_Text _textButton;
    [SerializeField] private Color _enable;
    [SerializeField] private Color _disable;

    public void Press()
    {
        _button.interactable = false;
        _pressedButton.enabled = true;
        _textButton.color = _enable;
    }

    public void Off()
    {
        _button.interactable = true;
        _pressedButton.enabled = false;
        _textButton.color = _disable;
    }
}
