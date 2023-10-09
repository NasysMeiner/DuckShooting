using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class CanvasUI : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGamesSdk.GameReady();
    }
}