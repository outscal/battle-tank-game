using UnityEngine;

public class PlayerTank_Ctrl <T>: MonoBehaviour where T: PlayerTank_Ctrl<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
