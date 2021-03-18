using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject player;

    public float[] speed; 
    public float[] rotSpeed;
    public float[] accuracy;
    public float[] interval;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        player = NPC.GetComponent<TankAI>().GetPlayer();//<-- this works
        Debug.Log(NPC.GetComponent<NormalEnemy>().normalSpawnManagerValues.accuracy);//<=--- error
        speed = new float[] { NPC.GetComponent<NormalEnemy>().normalSpawnManagerValues.speed, NPC.GetComponent<MediumEnemy>().mediumSpawnManagerValues.speed, NPC.GetComponent<HardEnemy>().hardSpawnManagerValues.speed };
        rotSpeed = new float[] { NPC.GetComponent<NormalEnemy>().normalSpawnManagerValues.rotationSpeed, NPC.GetComponent<MediumEnemy>().mediumSpawnManagerValues.rotationSpeed, NPC.GetComponent<HardEnemy>().hardSpawnManagerValues.rotationSpeed }; 
        accuracy = new float[] { NPC.GetComponent<NormalEnemy>().normalSpawnManagerValues.accuracy, NPC.GetComponent<MediumEnemy>().mediumSpawnManagerValues.accuracy, NPC.GetComponent<HardEnemy>().hardSpawnManagerValues.accuracy };
        interval = new float[] { NPC.GetComponent<NormalEnemy>().normalSpawnManagerValues.numberOfShellsPerSeconds, NPC.GetComponent<MediumEnemy>().mediumSpawnManagerValues.numberOfShellsPerSeconds, NPC.GetComponent<HardEnemy>().hardSpawnManagerValues.numberOfShellsPerSeconds };

    }
}
