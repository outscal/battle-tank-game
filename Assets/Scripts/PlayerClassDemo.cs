using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClassDemo : GameController<PlayerClassDemo>
{
    public override void Awake()
    {
        base.Awake();
        print("calling from Child..");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
