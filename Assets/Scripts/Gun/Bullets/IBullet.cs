public interface IBullet
{
    float Damage
    {
        get;
    }

    void SetVelocity();
    void MakeDamage(float damage);
}
