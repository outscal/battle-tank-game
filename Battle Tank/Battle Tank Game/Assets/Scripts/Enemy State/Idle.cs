using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
   
    public override void OnStateEnter(StateMachine Enemy)
    {
        Debug.Log("Entered in the idle State");
        // IsPatrol = true;        
    }
    
    public override void OnStateExit(StateMachine Enemy)
    {
        
    }

    public override void Tick(StateMachine Enemy)
    {
        // if(IsPatrol)
        {
            Enemy.SetState(Enemy.PatrolState);
        }
    }

}
