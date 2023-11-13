using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopCellGun : MonoBehaviour
{
    [Header("Prefab Components")]
    [SerializeField] private Image _iconGun;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _buttonGun;

    private Gun _gun;

    private bool _isEquip = false;
    private bool _isFire = false;

    public Gun Gun => _gun;
    public bool IsEquip => _isEquip;
    public bool IsFire => _isFire;

    public event UnityAction<Gun> ChangeGun;

    public void Init(Gun gun, FormGun formGun, bool isActive)
    {
        _gun = gun;
        _isEquip = isActive;

        _iconGun.sprite = formGun.IconGun;
        _name.text = formGun.Name;
    }

    public void EquipGun()
    {
        _isEquip = true;
        UpdateStateButton();
    }

    public void UnequipGun()
    {
        _isEquip = false;
        UpdateStateButton();
    }

    public void ClickButton()
    {
        EquipGun();
        ChangeGun?.Invoke(_gun);
    }

    private void UpdateStateButton()
    {
        _buttonGun.interactable = !_isEquip;
    }
}
