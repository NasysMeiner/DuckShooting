using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private int _countdownTime;
    [SerializeField] private TextMeshProUGUI _countdownDisplay;
    [SerializeField] private Image _dimed;

    private void OnEnable()
    {
        _dimed.gameObject.SetActive(true);
        StartCoroutine(CountdownToStart());
    }

    private IEnumerator CountdownToStart()
    {
        while(_countdownTime > 0)
        {
            _countdownDisplay.text = _countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            _countdownTime--;
        }

        _countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);

        _dimed.gameObject.SetActive(false);
        _countdownDisplay.gameObject.SetActive(false);
    }
}
