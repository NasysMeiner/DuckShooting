using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsGunPlayer : MonoBehaviour
{
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] private List<Button> _slots;

    private int _currentSlotIndex = 0;

    private void Awake()
    {
        ChangeActiveSlot(0);
    }

    public void ChangeActiveSlot(int index)
    {
        SetActive(index);
        _shopGun.SetActiveSlot(index);
    }

    public void SetActive(int newIndex)
    {
        if(newIndex != _currentSlotIndex)
            _slots[_currentSlotIndex].interactable = true;

        _slots[newIndex].interactable = false;
        _currentSlotIndex = newIndex;
    }
}
