using UnityEngine;

public class SingletonMB<T> : MonoBehaviour where T : SingletonMB<T>
{
    private static T instance;
    public static T Instance => instance;

    protected void Awake()
    {
        if (instance) Destroy(gameObject);
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
    }
}