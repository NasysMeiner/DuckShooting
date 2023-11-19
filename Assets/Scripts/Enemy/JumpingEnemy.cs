using System.Threading.Tasks;
using UnityEngine;

public class JumpingEnemy : Enemy
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;

    private int _millisekundy = 1000;
    private int _jumpCooldown = 3;

    private void Start()
    {
        Jump();
    }

    private async void Jump()
    {
        while (true)
        {
            Unknown();

            await Task.Delay((int)(_jumpCooldown * _millisekundy));
        }
    }

    private void Unknown()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    private void Gravity(bool state)
    {
        _rigidbody.useGravity = true;
    }
}
