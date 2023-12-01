using UnityEngine;

public class EnemyGrenade : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            Instantiate(_explosionEffect, transform.position, transform.rotation);
            Collider[] touchedObjects = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider touchedObject in touchedObjects)
            {
                Player player = touchedObject.GetComponent<Player>();

                if(player != null)
                {
                    player.TakeDamage(_damage);
                }
            }

            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Player player))
        {
            Instantiate(_explosionEffect, transform.position, transform.rotation);
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}