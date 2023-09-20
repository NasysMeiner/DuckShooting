using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private Sprite _musicOff;
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Button _musicButton;
    [SerializeField] private AudioSource _musicAudio;

    [Header("SFX")]
    [SerializeField] private Sprite _sfxOff;
    [SerializeField] private Sprite _sfxOn;
    [SerializeField] private Button _sfxButton;
    [SerializeField] private AudioSource _SFXAudio;

    private bool IsOnMusic;
    private bool IsOnSFX;

    private void Start()
    {
        IsOnMusic = true;
        IsOnSFX = true;
    }

    private void Update()
    {
        ChangeMusicVolume();
    }

    private void ChangeMusicVolume()
    {
        if (PlayerPrefs.GetInt(Constantes.StrMusic) == 0)
        {
            _musicButton.GetComponent<Image>().sprite = _musicOn;
            _musicAudio.enabled = true;
            IsOnMusic = true;
        }
        else
        {
            _musicButton.GetComponent<Image>().sprite = _musicOff;
            _musicAudio.enabled = false;
            IsOnMusic = false;
        }
    }

    public void OffMusicSound()
    {
        if (IsOnMusic == false)
        {
            PlayerPrefs.SetInt(Constantes.StrMusic, 0);
        }
        else
        {
            PlayerPrefs.SetInt(Constantes.StrMusic, 1);
        }
    }
    private void ChangeSFXVolume()
    {
        if (PlayerPrefs.GetInt(Constantes.StrSFX) == 0)
        {
            _sfxButton.GetComponent<Image>().sprite = _sfxOn;
            _SFXAudio.enabled = true;
            IsOnSFX = true;
        }
        else
        {
            _sfxButton.GetComponent<Image>().sprite = _sfxOff;
            _SFXAudio.enabled = false;
            IsOnSFX = false;
        }
    }

    public void OffSFXSound()
    {
        if (IsOnSFX == false)
        {
            PlayerPrefs.SetInt(Constantes.StrSFX, 0);
        }
        else
        {
            PlayerPrefs.SetInt(Constantes.StrSFX, 1);
        }
    }
}
