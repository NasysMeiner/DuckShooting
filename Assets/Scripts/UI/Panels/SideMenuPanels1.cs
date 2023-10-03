using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideMenuPanels1 : MonoBehaviour
{
    [SerializeField] private GameObject[] _anotherPanels;

    public void OffPanels()
    {
        for (int i = 0; i < _anotherPanels.Length; i++)
        {
            _anotherPanels[i].SetActive(false);
        }
    }
}