using UnityEngine;

public class TankController<T> : MonoBehaviour where T : TankController<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("trying to create duplicate singleton");
            Destroy(this);
        }
    }
}
