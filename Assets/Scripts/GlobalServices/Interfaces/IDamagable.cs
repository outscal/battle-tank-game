
namespace GlobalServices
{
    // Interface for damage system. All objects that sholud take damage must be inherited from IDamagable.
    public interface IDamagable 
    {
        void TakeDamage(int damage);
    }
}
