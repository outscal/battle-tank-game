using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank<T> : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Display(); 
    }

    // Update is called once per frame
    void Display()
    {
        Debug.Log("hello i am " + typeof(T));
        
    }
}