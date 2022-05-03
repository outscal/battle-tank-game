using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Receiver : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadNewScene", 3f);

        Singletons.instance.DoSomething();

    }
    void LoadNewScene()
    {
        SceneManager.LoadScene("Game");
    }
}// class

