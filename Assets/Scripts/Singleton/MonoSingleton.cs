using UnityEngine;

public class MonoSingleton : MonoBehaviour
{
    private static MonoSingleton instance;
    public static MonoSingleton Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }
    public void PlayGame()
    {

    }
}

public class GameWorld : MonoSingleton 
{
    
}

public class World : MonoBehaviour 
{
    private void Awake()
    {
        GameWorld.Instance.PlayGame();
    }
}