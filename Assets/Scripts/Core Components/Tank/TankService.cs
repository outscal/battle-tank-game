using UnityEngine;

public class TankService<T> : MonoBehaviour where T : TankService<T>
{
    protected static T instance;
    public static T Instance { get { return instance; } }

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
        Debug.LogWarning("TankService::Initialize(): Expected method to be overrided");
    }
}