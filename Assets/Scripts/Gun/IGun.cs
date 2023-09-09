using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    Bullet SearchBullet();
    Bullet SetTypeDamage(Bullet bullet);
    void StartFire();
    void StopFire();
}
