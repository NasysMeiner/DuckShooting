using System.Collections.Generic;
using UnityEngine;

public class SlotsGunPlayer : MonoBehaviour
{
    [SerializeField] private ShopGun _shopGun;
    [SerializeField] private List<SlotGun> _slots;

    private int _currentSlotIndex = 0;

    private void Awake()
    {
        ChangeActiveSlot(_currentSlotIndex);
    }

    public void ChangeActiveSlot(int index)
    {
        SetActive(index);
        //_shopGun.SetActiveSlot(index);
    }

    public void SetActive(int newIndex)
    {
        if (newIndex != _currentSlotIndex)
            _slots[_currentSlotIndex].Off();

        _slots[newIndex].Press();
        _currentSlotIndex = newIndex;
    }
}
