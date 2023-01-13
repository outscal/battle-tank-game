using UnityEngine;
public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    private static T instance;

    public static T Instance {get {return instance;}}

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}
