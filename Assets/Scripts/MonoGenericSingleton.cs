using UnityEngine;

public class MonoGenericSingleton<T> : MonoBehaviour where T : MonoGenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = (T)this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class PlayerTankController : MonoGenericSingleton<PlayerTankController>
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

public class EnemyTankController : MonoGenericSingleton<EnemyTankController>
{
    private void Start()
    {
        PlayerTankController.Instance.MovePlayer();
    }
}