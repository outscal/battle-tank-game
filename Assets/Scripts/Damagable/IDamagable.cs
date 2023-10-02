public interface IDamagable
{
    public abstract bool TakeDamage(float damage);
    public abstract bool GiveDamage(IDamagable damagable);
}
