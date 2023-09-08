using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraWindow : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 0.0001f;
    [SerializeField] private float _minusSpeed = 0.0001f;

    private Movement _player;
    private bool _isInside = true;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Movement player))
        {
            _player = player;
            _isInside = false;
            StartCoroutine(Move());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BorderPlayer player))
            _isInside = true;
    }

    private IEnumerator Move()
    {
        bool isWork = true;
        float speed = _startSpeed;

        while (isWork)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, speed);

            if (_isInside)
                speed -= _minusSpeed;

            if (speed <= 0)
                isWork = false;

            yield return new WaitForFixedUpdate();
        }
    }
}
