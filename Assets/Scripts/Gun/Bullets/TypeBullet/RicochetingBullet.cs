using UnityEngine;

public class RicochetingBullet : Bullet
{
    [SerializeField] private int _numberMaxRicochets = 5;
    [SerializeField] private int _millisecondsWait = 100;

    private Enemy _nextTarget = null;

    private int _numberRicochets = -1;

    private Vector3 _directionNextTarget => (_nextTarget.transform.position - transform.position).normalized;

    private void OnDisable()
    {
        //_ammoBag.BoxTrigger.ChangeEnemy -= OnChangeEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy == _nextTarget || _numberRicochets == 0)
            {
                enemy.TakeDamage(_damage);
                SearchNextTarget(enemy);
            }
        }
    }

    public override void Init(float speed, float damage, AmmoBag ammoBag)
    {
        base.Init(speed, damage, ammoBag);

        //_ammoBag.BoxTrigger.ChangeEnemy += OnChangeEnemy;
    }

    public override void SetVelocity()
    {
        if (_numberRicochets == -1)
        {
            _numberRicochets++;
            base.SetVelocity();

            return;
        }

        if (_nextTarget != null)
        {
            _numberRicochets++;
            _rigidbody.velocity = _directionNextTarget * _speed;
            Vector3 rotate = new Vector3(_directionNextTarget.x, _directionNextTarget.y, _directionNextTarget.z);
            transform.rotation = Quaternion.LookRotation(rotate);
        }
        else
        {
            ResetBullet();
        }
    }

    private void OnChangeEnemy(Enemy enemy)
    {
        if (_nextTarget == enemy)
        {
            _numberRicochets--;
            SearchNextTarget(enemy);
        }
    }

    private void SearchNextTarget(Enemy enemy)
    {
        //_nextTarget = _ammoBag.BoxTrigger.SearchTarget(enemy);

        if (_numberRicochets == _numberMaxRicochets)
        {
            ResetBullet();

            return;
        }

        SetVelocity();
    }

    private void ResetBullet()
    {
        _numberRicochets = -1;
        _nextTarget = null;

        PullOutOfGun();
    }
}
