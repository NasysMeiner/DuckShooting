using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconSlot : MonoBehaviour
{
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    private Image _icon;

    private void Awake()
    {
        _icon = GetComponent<Image>();

    }

    public void ActiveSlot()
    {
        _icon.color = _activeColor;
    }

    public void InactiveSlot()
    {
        _icon.color = _inactiveColor;
    }
}
