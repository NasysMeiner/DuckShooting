using UnityEngine;
using UnityEngine.UI;

public class SlotGun : ButtonAnimation
{
    [SerializeField] private Image _arrowIcon;

    public override void Press()
    {
        base.Press();
        _arrowIcon.enabled = true;
    }

    public override void Off()
    {
        base.Off();
        _arrowIcon.enabled = false;
    }
}
