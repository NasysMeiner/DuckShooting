using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideMenuPanels1 : MonoBehaviour
{
    [SerializeField] private GameObject[] _anotherActiveButtons;
    [SerializeField] private Transform _panel;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;

    private void OnEnable()
    {
        _panel.DOLocalMove(_endPosition, 0.4f).SetUpdate(UpdateType.Normal, true);
    }

    private void FixedUpdate()
    {
        Cancel();
    }

    private void Cancel()
    {
        for (int i = 0; i < _anotherActiveButtons.Length; i++)
        {
            if (_anotherActiveButtons[i].activeSelf == true)
            {
                _panel.DOLocalMove(_startPosition, 0.4f).SetUpdate(UpdateType.Normal, true).OnComplete(Close);
            }
        }
    }

    private void Close()
    {
        _panel.transform.localPosition = new Vector2(0f, -1151.6f);
        _panel.gameObject.SetActive(false);
    }
}