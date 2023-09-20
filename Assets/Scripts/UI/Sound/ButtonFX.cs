using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField] private AudioSource _myFX;
    [SerializeField] private AudioClip _click;

    public void ClickSound()
    {
        _myFX.PlayOneShot(_click);
    }
}
