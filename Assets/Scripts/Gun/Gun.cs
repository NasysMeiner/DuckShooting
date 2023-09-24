using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private ShotPoint _shotPoint;
    [SerializeField] private Transform _pointPosition;

    private bool _isStart = false;
    private Bullet _bullet;
    private float _timeShot = 1;
    private StockBullet _stockBullet;

    private int _millisekundy = 1000;

    public Bullet Bullet => _bullet;
    public Transform PointPosition => _pointPosition;

    public void Init(Bullet bullet, float timeShot, StockBullet stockBullet)
    {
        _bullet = bullet;
        _timeShot = timeShot;
        _stockBullet = stockBullet;
    }

    public void SetTypeBullet(Bullet bullet)
    {
        _bullet = bullet;
    }

    public void StartFire()
    {
        if (_isStart == false)
        {
            _isStart = true;
            TakeFire();
        }
    }

    public void StopFire()
    {
        if (_isStart == true)
            _isStart = false;
    }

    public Bullet SearchBullet()
    {
        return _stockBullet.SearchFreeBullet();
    }

    public virtual Bullet SetTypeDamage(Bullet bullet)
    {
        return bullet;
    }

    private void TakeShot()
    {
        Bullet bullet = SearchBullet();

        if (bullet != null)
        {
            bullet.SetInGun();
            bullet = SetTypeDamage(bullet);
            bullet.transform.position = _shotPoint.transform.position;
            bullet.SetVelocity();
        }
    }

    private async void TakeFire()
    {
        while (true)
        {
            if (_isStart == false)
            {
                break;
            }

            TakeShot();

            await Task.Delay((int)(_timeShot * _millisekundy));
        }
    }
}
