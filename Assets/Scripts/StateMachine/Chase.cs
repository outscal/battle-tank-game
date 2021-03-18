using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : NPCBaseFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = player.transform.position - NPC.transform.position;

        switch (NPC.name)
        {
            case "NormalTank":
                NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotSpeed[0] * Time.deltaTime);
                NPC.transform.Translate(0, 0, Time.deltaTime * speed[0]);
                break;
            case "MediumTank":
                NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotSpeed[1] * Time.deltaTime);
                NPC.transform.Translate(0, 0, Time.deltaTime * speed[1]);
                break;
            case "HardTank":
                NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotSpeed[2] * Time.deltaTime);
                NPC.transform.Translate(0, 0, Time.deltaTime * speed[2]);
                break;
            default:
                break;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
