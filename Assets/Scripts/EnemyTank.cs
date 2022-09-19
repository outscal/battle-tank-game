using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : GenericSingleton<EnemyTank>
{
    protected override void MakeSingleton()  //tried overriding the MakeSingleton function
    {
        Debug.Log("override the make singleton function in main, in a way but not entirely");
        base.MakeSingleton();
        //some custom code possibly
    }    
}
