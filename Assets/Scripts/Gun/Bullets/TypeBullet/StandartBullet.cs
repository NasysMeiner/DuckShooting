using UnityEngine;

public class StandartBullet : Bullet
{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy) || other.gameObject.TryGetComponent(out Dummy Dummy))
        {
            if (enemy != null)
                enemy.TakeDamage((int)_damage);

            //PullOutOfGun();
        }
    }
}
