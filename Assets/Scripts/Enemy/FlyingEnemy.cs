using System.Threading.Tasks;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public GameObject GrenadePref;
    public float throwForce = 300;
    private int _atackCooldown = 3;
    private int _millisekundy = 1000;

    private void Start()
    {
        Atack();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    private async void Atack()
    {
        while (true)
        {
            ThrowBomb();

            await Task.Delay((int)(_atackCooldown * _millisekundy));
        }
    }

    private void ThrowBomb()
    {
        GameObject grenadeObject = Instantiate(GrenadePref, transform.position, transform.rotation);
    }
}
