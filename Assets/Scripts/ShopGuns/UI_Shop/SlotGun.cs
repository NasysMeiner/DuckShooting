using UnityEngine;
using UnityEngine.UI;

public class SlotGun : ButtonAnimation
{
    [SerializeField] private Image _arrowIcon;

    public override void Press()
    {
        base.Press();

        if (_arrowIcon != null)
            _arrowIcon.enabled = true;
    }

    public override void Off()
    {
        base.Off();

        if (_arrowIcon != null)
            _arrowIcon.enabled = false;
    }
}
