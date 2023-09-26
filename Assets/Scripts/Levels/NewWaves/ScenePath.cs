using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePath : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathPoints = new List<Transform>();

    private void Awake()
    {
        Destroy(gameObject);
    }

    public void AddPoint(Transform point)
    {
        _pathPoints.Add(point);
    }

    public List<Vector3> GetPathPoints()
    {
        List<Vector3> points = new List<Vector3>();

        foreach (var item in _pathPoints)
        {
            points.Add(item.position);
        }

        return points;
    }
}
