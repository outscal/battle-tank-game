
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T: SingleTon<T>
{
    private static T instance;
    public T InsTance { get { return instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Some One trying to create duplicate of it");
            Destroy(this);
        }
    }
}
