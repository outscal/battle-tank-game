using UnityEngine;

public class Patrol : State
{
    public override void OnStateEnter(StateMachine Enemy)
    {
       Debug.Log("Entered in the patrol State");
    }   
    
    public override void OnStateExit(StateMachine Enemy)
    {

    }

    public override void Tick(StateMachine Enemy)
    {

    }
   
}
