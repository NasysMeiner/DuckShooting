using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class SlotAmmo : ButtonAnimation
{
    private TypeBullet _typeBullet;

    public TypeBullet TypeBullet => _typeBullet;

    public event UnityAction<TypeBullet> ChangeBullet;

    public void InitSlotAmmo(TypeBullet typeBullet)
    {
        _textButton.text = $"{typeBullet}";
        _typeBullet = typeBullet;
    }

    public override void Press()
    {
        base.Press();
    }

    public override void Off()
    {
        base.Off();
    }

    public void ClickButton()
    {
        ChangeBullet?.Invoke(_typeBullet);
    }
}
