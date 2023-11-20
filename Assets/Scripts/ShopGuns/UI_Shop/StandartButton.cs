using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StandartButton : ButtonAnimation
{
    [SerializeField] private Panel _panel;
    [SerializeField] private int _timeMilliseconds = 300;

    public override void Press()
    {      
        base.Press();

        if (_panel.IsOpen)
            _panel.Close();
        else
            _panel.Open();

        ReturnOriginalState();
    }

    public override void Off()
    {
        base.Off();
    }

    private async void ReturnOriginalState()
    {
        await Task.Delay(_timeMilliseconds);

        Off();
    }
}
