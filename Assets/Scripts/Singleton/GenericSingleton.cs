using UnityEngine;

// Creating a Generic Singleton class
public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static GenericSingleton<T> instance; 
    public static GenericSingleton<T> Instance { get { return instance; } }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
