using UnityEngine;
using Agava.YandexGames;

public class CanvasUI : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGamesSdk.GameReady();
    }
}