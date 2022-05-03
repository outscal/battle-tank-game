using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sender : MonoBehaviour
{
    void Start()
    {
        Singletons.instance.lifeCount = 3;
        print("The value of life count is" + Singletons.instance.lifeCount);
       
        Invoke("LoadNewScene", 3f);

    }
    void LoadNewScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}// class