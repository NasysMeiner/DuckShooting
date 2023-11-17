using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    Queue<Bullet> SearchNewClip();
    Bullet SetTypeDamage(Bullet bullet);
    void StartFire();
    void StopFire();
}
