using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private AmmoBag _bulletStock;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.PullOutOfGun();
        }
    }
}
