using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private ShotPoint _shotPoint;
    [SerializeField] private Transform _pointPosition;

    private float _timeShot = 1;
    private float _damage = 1;
    private int _storeSize = 10;
    private float _equipmentTime;

    private AmmoBag _ammoBag;

    private bool _isStart = false;
    private int _millisekundy = 1000;

    public Transform PointPosition => _pointPosition;
    public float EquipmentTime => _equipmentTime;

    public event UnityAction ActiveGun;
    public event UnityAction DeactiveGun;

    public void Init(float timeShot, AmmoBag ammoBag, float equipmentTime)
    {
        _timeShot = timeShot;
        _ammoBag = ammoBag;
        _equipmentTime = equipmentTime;
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
        return _ammoBag.SearchFreeBullet();
    }

    public virtual Bullet SetTypeDamage(Bullet bullet)
    {
        return bullet;
    }

    public void Activate()
    {
        ActiveGun?.Invoke();
    }

    public void Deactivate()
    {
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
