using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
{
    GameObject[] waypoints;
    int currentWP;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0)
            return;
     
        //distance calculation where is npc in relation to wp
        if (Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < accuracy[0] || Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < accuracy[1] || Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < accuracy[2])
        {
            currentWP++;
            //cycle of wp
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        //slerp - slowly turn
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
