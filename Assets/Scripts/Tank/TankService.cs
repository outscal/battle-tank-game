using UnityEngine;

// A Singleton TankService class will help spawning Tank in the game
public class TankService<T> : MonoBehaviour where T : TankService<T>
{
    [SerializeField]
    protected float tankSpeed = 3f;

    [SerializeField]
    protected float tankHealth = 100f;

    protected static T instance;
    public static T Instance { get { return instance; } }

    protected TankModel TankModel;
    protected TankController TankController;

    [SerializeField]
    protected TankView TankViewPrefab;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
    }

    protected virtual void Initialize()
    {
        TankModel = new TankModel(tankSpeed, tankHealth);
        TankController = new TankController(TankModel, TankViewPrefab);
    }
}