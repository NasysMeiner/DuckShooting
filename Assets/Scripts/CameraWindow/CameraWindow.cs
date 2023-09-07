using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWindow : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 0.0001f;

    private Movement _player;
    private Collider _collider;
    private bool _isInside = true;

    public Vector3 CenterPlayer
    {
        get
        {
            return new Vector3(_collider.bounds.center.x, _collider.bounds.center.y, _collider.bounds.center.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Movement player))
        {
            Debug.Log("Exit");
            _player = player;
            _isInside = false;
            _collider = other;
            StartCoroutine(Move());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Movement player))
        {
            _isInside = true;
            Debug.Log("Stop");
        }
    }

    private IEnumerator Move()
    {
        bool isWork = true;

        while (isWork)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _startSpeed);

            if (_isInside)
                isWork = false;

            yield return null;
        }
    }
}
