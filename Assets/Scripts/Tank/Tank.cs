using UnityEngine;

public class Tank<T> : MonoBehaviour where T : Tank<T>
{
    static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Tank:Awake():: {DESTROYING DUPLICATE INSTANCE}");
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Tank:Awake():: {STARTED}");
        }
    }
}