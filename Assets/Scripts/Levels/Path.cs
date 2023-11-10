using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Path", menuName = "GameSO/Path")]
public class Path : ScriptableObject
{
    public List<Vector3> Points = new List<Vector3>();
#if UNITY_EDITOR
    [ContextMenu("Save path")]
    private void SavePoints()
    {
        var enemyPath = FindObjectOfType<ScenePath>();

        if (enemyPath != null)
        {
            Points = enemyPath.GetPathPoints();
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        }
    }

    [ContextMenu("Load points")]
    private void LoadPoints()
    {
        GameObject path = new GameObject("Path");
        ScenePath scenePath = path.AddComponent<ScenePath>();

        for (int i = 0; i < Points.Count; i++)
        {
            GameObject point = new GameObject($"Point{i}");
            point.transform.SetParent(path.transform);
            point.transform.position = Points[i];
            scenePath.AddPoint(point.transform);
        }
    }
#endif
}
