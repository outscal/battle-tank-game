using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public NormalEnemy NPC;
    public GameObject player;

    public float speed; 
    public float rotSpeed;
    public float accuracy;
    public float interval;
    public bool isDead;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.GetComponent<NormalEnemy>();

        var gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("There is no instance of GameManager in the scene", this);
            return;
        }
        player = gameManager.playerTank;

        speed = NPC.tankConfig.speed;
        rotSpeed = NPC.tankConfig.rotationSpeed;
        accuracy = NPC.tankConfig.accuracy;
        interval = NPC.tankConfig.numberOfShellsPerSeconds;
        isDead = NPC.tankConfig.isDead;
   }
}
