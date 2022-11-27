internal interface IDamagable
{
    void TakeDamage(BulletType bullettype, int damage);
    void TakeDamage(int damage);
}