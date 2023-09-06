using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private BulletStore _bulletStore;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out Bullet bullet))
        {
            _bulletStore.AddBullet(bullet);
        }
    }
}
