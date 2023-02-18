using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            Debug.Log("One");
            Instance = (T)this;
        } else
        {
            Debug.Log("Two");
            Destroy(Instance);
        }
    }
}
