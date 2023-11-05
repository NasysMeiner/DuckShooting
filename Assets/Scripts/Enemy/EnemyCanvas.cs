using UnityEngine;

public class EnemyCanvas : MonoBehaviour
{
    private Transform _camera;

    private void OnEnable()
    {
        _camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera);
    }
}
