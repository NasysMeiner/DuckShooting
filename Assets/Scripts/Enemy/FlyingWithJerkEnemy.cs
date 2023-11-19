using System.Threading.Tasks;
using UnityEngine;

public class FlyingWithJerkEnemy : Enemy
{
    [SerializeField] private float _jerkSpeed;
    
    private int _jerkCooldown = 3;
    private float _standartSpeed;
    private int _millisekundy = 1000;

    private void Start()
    {
        _standartSpeed = base._speed;
        Jerk();
    }

    private async void Jerk()
    {
        while (true)
        {
            Boost();

            await Task.Delay((int)(_jerkCooldown * _millisekundy));
        }
    }

    private void Boost()
    {
        base._speed = _jerkSpeed;
        Invoke("Slowdown", 0.5f);
    }

    private void Slowdown()
    {
        base._speed = _standartSpeed;
    }
}
