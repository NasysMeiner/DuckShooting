using System.Collections.Generic;
using UnityEngine;

public class AmmoBag : MonoBehaviour
{
    [SerializeField] private BoxTrigger _boxTrigger;

    private List<Bullet> _bullets = new List<Bullet>();

    public BoxTrigger BoxTrigger => _boxTrigger;

    public void AddBullet(Bullet bullet)
    {
        //bullet.PullOutOfGun();
        bullet.transform.position = transform.position;
        _bullets.Add(bullet);
    }

    public Bullet SearchFreeBullet()
    {
        foreach(Bullet bullet in _bullets)
        {
            if(bullet.IsInCannon == false)
                return bullet;
        }

        return null;
    }
}