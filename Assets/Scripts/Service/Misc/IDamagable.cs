public interface IDamagable
{
    void GetDamage(float damage, TypeDamagable type);
}
public enum TypeDamagable
    {
        Player,
        Enemy,
        Bullet,
        Environment
    }