using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBag : MonoBehaviour
{
    private List<List<Bullet>> _typesBullets = new List<List<Bullet>>();

    public void AddBullet(Bullet bullet)
    {
        List<Bullet> listBullet = SearchTypeBullet(bullet.TypeBullet);

        if (listBullet != null)
            listBullet.Add(bullet);
        else
            CreateNewListTypeBullet(bullet);

        bullet.transform.position = transform.position;
    }

    public Queue<Bullet> ReloadClip(TypeBullet typeBullet, int count)
    {
        Queue<Bullet> queue = new Queue<Bullet>();
        List<Bullet> listBullet = SearchTypeBullet(typeBullet);

        if(listBullet == null)
            throw new NotImplementedException("Type bullet not found");

        foreach (Bullet bullet in listBullet)
        {
            if (bullet.IsInCannon == false)
                queue.Enqueue(bullet);

            if (queue.Count == count)
                break;
        }

        return queue;
    }

    private List<Bullet> SearchTypeBullet(TypeBullet typeBullet)
    {
        foreach(List<Bullet> type in _typesBullets)
        {
            if (type[0].TypeBullet == typeBullet)
                return type;
        }

        return null;
    }

    private void CreateNewListTypeBullet(Bullet bullet)
    {
        List<Bullet> newType = new List<Bullet> { bullet };
        _typesBullets.Add(newType);
    }
}