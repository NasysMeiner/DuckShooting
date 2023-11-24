using System.Linq;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour
{
    public GameObject ExplosionEffect;
    public float GrenadeRadius;
    public float ExplosionForce;
    public float DamageRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    //private void Explode()
    //{
    //    Instantiate(ExplosionEffect, transform.position, transform.rotation);
    //    Collider[] touchedObjects = Physics.OverlapSphere(transform.position, GrenadeRadius).Where(x => x.tag == "Player").ToArray();

    //    foreach (Collider touchedObject in touchedObjects)
    //    {
    //        Rigidbody rigidbody = touchedObject.GetComponent<Rigidbody>();

    //        if (rigidbody != null)
    //        {
    //            rigidbody.AddExplosionForce(ExplosionForce, transform.position, GrenadeRadius);
    //        }

    //        var target = touchedObject.gameObject.GetComponent<Player>();
    //        target.TakeDamage(DamageRate);

    //    }

    //    Destroy(gameObject);
    //}
}