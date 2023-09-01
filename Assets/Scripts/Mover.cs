using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.up * _speed;
    }
}