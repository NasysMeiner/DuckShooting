using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healthPoint = 100f;

    private IGun _currentGun;

    public void TakeDamage(float damage)
    {
        Debug.Log("Есть пробитие!");
        _healthPoint -= damage;
    }
}
