using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIShopCell : MonoBehaviour
{
    [SerializeField] private Image _iconGun;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _buttonGun;

    private Gun _gun = null;

    public Gun Gun => _gun;

    public event UnityAction<Gun> ChangeGun;

    private void OnEnable()
    {
        if(_gun != null)
        {
            _gun.DeactiveGun += DeactiveButton;
            _gun.ActiveGun += ActiveButton;
        }
    }

    private void OnDisable()
    {
        if (_gun != null)
        {
            _gun.DeactiveGun -= DeactiveButton;
            _gun.ActiveGun -= ActiveButton;
        }   
    }

    public void Init(Gun gun)
    {
        _gun = gun;
        _gun.DeactiveGun += DeactiveButton;
        _gun.ActiveGun += ActiveButton;
        _iconGun.sprite = gun.Sprite;
        _name.text = gun.Name;
    }

    public void ClickButton()
    {
        ChangeGun?.Invoke(_gun);
    }

    private void ActiveButton()
    {
        _buttonGun.interactable = false;
    }

    private void DeactiveButton()
    {
        _buttonGun.interactable = true;
    }
}
