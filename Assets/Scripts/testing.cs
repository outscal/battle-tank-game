using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : EnemyTank
{
    //script just made to test function overriding in Enemy Tank, and fun news, its happening!!
    private void Awake()
    {
        Debug.Log("here awake will be called, then the MakeSingleton function for this particular child class");
        base.MakeSingleton();
    }
}
