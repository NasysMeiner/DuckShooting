using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBag : MonoBehaviour
{
    [SerializeField] private SlotAmmo _prefabSlotAmmo;
    [SerializeField] private Transform _transformSlotAmmo;

    private List<List<Bullet>> _typesBullets = new List<List<Bullet>>();
    private List<SlotAmmo> _ammoView = new List<SlotAmmo>();

    private ShopGun _shopGun;
    private ArsenalPlayer _arsenalPlayer;

    private void OnDisable()
    {
        _shopGun.ChangeCurrentSlotIndex -= ViewTypeBullet;
    }

    public void InitAmmoBag(ShopGun shopGun, ArsenalPlayer arsenalPlayer)
    {
        _arsenalPlayer = arsenalPlayer;
        _shopGun = shopGun;
        _shopGun.ChangeCurrentSlotIndex += ViewTypeBullet;
    }

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
        SlotAmmo newSlot = Instantiate(_prefabSlotAmmo, _transformSlotAmmo);
        newSlot.InitSlotAmmo(bullet.TypeBullet);
        _ammoView.Add(newSlot);
        newSlot.ChangeBullet += ChangeBullet;

        List<Bullet> newType = new() { bullet };
        _typesBullets.Add(newType);
    }

    private void ViewTypeBullet(TypeBullet typeBullet)
    {
        foreach (SlotAmmo slotAmmo in _ammoView)
        {
            if (slotAmmo.IsActive && slotAmmo.TypeBullet != typeBullet)
                slotAmmo.Off();
            else if(slotAmmo.TypeBullet == typeBullet)
                slotAmmo.Press();
        }
    }

    private void ChangeBullet(TypeBullet typeBullet)
    {
        _arsenalPlayer.ChangeBullet(typeBullet, _shopGun.CurrentSlotIndex);
        ViewTypeBullet(typeBullet);
    }
}