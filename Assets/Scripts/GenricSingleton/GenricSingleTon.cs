
using UnityEngine;

public class GenricSingleTon<T> : MonoBehaviour where T : GenricSingleTon<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(this);

        }
        else
        {
            Destroy(this);
        }

    }
}
