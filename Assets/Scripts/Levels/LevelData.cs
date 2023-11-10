using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "GameSO/Level")]
public class LevelData : ScriptableObject
{
    public List<NewWave> Waves = new List<NewWave>();
}

[System.Serializable]
public class NewWave
{
    public GameObject EnemyPrefab;
    [Range(1, 100)]
    public int CountInWave;
    [Range(1, 360)]
    public float WaitAfterWave;
}
