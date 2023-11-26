using System.Linq;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _radius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            Instantiate(_explosionEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    //private void Explode()
    //{
    //    Instantiate(_explosionEffect, transform.position, transform.rotation);
    //    Collider[] touchedObjects = Physics.OverlapSphere(transform.position, _radius).Where(x => x.tag == "Player").ToArray();

    //    foreach (Collider touchedObject in touchedObjects)
    //    {
    //        Rigidbody rigidbody = touchedObject.GetComponent<Rigidbody>();

    //        if (rigidbody != null)
    //        {
    //            rigidbody.AddExplosionForce(_explosionForce, transform.position, _radius);
    //        }

    //        var target = touchedObject.gameObject.GetComponent<Player>();
    //        target.TakeDamage(_damage);

    //    }

    //    Destroy(gameObject);
    //}
}