
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }
    protected virtual void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(this);
        }

        Debug.Log("Made from Generic Singleton!");
    }
}
