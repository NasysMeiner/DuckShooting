using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private ShotPoint _shotPoint;
    [SerializeField] private Transform _pointPosition;

    private bool _isStart = false;
    private Bullet _bullet;
    private float _timeShot = 1;
    private StockBullet _stockBullet;
    private string _name;
    private Sprite _sprite;
    private bool _isActive = false;

    private int _millisekundy = 1000;

    public Bullet Bullet => _bullet;
    public Transform PointPosition => _pointPosition;
    public string Name => _name;
    public Sprite Sprite => _sprite;
    public bool IsActive => _isActive;

    public event UnityAction ActiveGun;
    public event UnityAction DeactiveGun;

    public void Init(Bullet bullet, float timeShot, StockBullet stockBullet, string name, Sprite sprite)
    {
        _bullet = bullet;
        _timeShot = timeShot;
        _stockBullet = stockBullet;
        _name = name;
        _sprite = sprite;
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

    public void Activate()
    {
        _isActive = true;
        ActiveGun?.Invoke();
    }

    public void Deactivate()
    {
        _isActive = false;
        DeactiveGun?.Invoke();
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
