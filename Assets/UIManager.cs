using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;
    public Text bulletAchievemntText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public GameObject tenBullets;
}
