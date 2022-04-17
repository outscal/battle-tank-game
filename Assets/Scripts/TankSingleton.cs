using UnityEngine;

public class TankSingleton<T> : MonoBehaviour where T : TankSingleton<T>    //generic singleton
{

    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class PlayerTankController : TankSingleton<PlayerTankController>
{
    protected override void Awake()     //overriding parent Awake
    {
        base.Awake();
        //custom Awake of child
    }

    public void MovePlayer()
    {

    }
}

public class EnemyTankController : TankSingleton<EnemyTankController>
{
    private void Start()
    {
        PlayerTankController.Instance.MovePlayer();
    }
}