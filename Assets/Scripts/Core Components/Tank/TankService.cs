using UnityEngine;

// A Singleton TankService class will help spawning Tank in the game
public class TankService<T> : MonoBehaviour where T : TankService<T>
{
    [SerializeField]
    TankScriptableObject tankScriptableObject;

    protected static T instance;
    public static T Instance { get { return instance; } }

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
        TankModel tankModel = new TankModel(tankScriptableObject.Speed, tankScriptableObject.Health, tankScriptableObject.Damage, tankScriptableObject.Damage);

        TankController tankController = new TankController(tankModel, TankViewPrefab);
    }
}