using UnityEngine;

public class MonoGenericSingleton<T> : MonoBehaviour where T : MonoGenericSingleton<T>    //generic singleton
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        MakeSingleton();
    }

    public void MakeSingleton()
    {
        if (instance == null)
        {
            instance = (T)this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}