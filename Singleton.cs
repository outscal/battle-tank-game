public class TankBase<T> where T : TankBase<T>
{
    private static T instance;

    // Protected constructor to prevent instantiation from other classes.
    protected TankBase()
    {
    }
    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = Activator.CreateInstance(typeof(T), true) as T;
        }
        return instance;
    }
}

public class PlayerTank : TankBase<PlayerTank>
{
}

public class EnemyTank : TankBase<EnemyTank>
{

}
