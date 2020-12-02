using UnityEngine;

public class PatrolState : State
{
    public EnemyController ec;
    private float speed;
    public Transform movespot;
    private float minX;
    private float minZ;
    private float maxX;
    private float maxZ;

    private void Start()
    {
        Debug.Log("Starting Patrol");
        speed = 20f;
        minX = -30f;
        maxX = 36f;
        minZ = -31.3f;
        maxZ = 20f;
        movespot = new GameObject("MP").transform;
        movespot.position = new Vector3(UnityEngine.Random.Range(minX,maxX),0, UnityEngine.Random.Range(minZ,maxZ));

    }

    public override void EnterState()
    {
        Debug.Log("Patrolling state for tank");


    }

    private void Update()
    {
        ec.transform.position = Vector3.MoveTowards(ec.transform.position, movespot.position, speed * Time.deltaTime);
        ec.transform.LookAt(movespot);
        //ec.transform.rotation = Quaternion.LookRotation(movespot.position);
        if (Vector3.Distance(ec.transform.position, movespot.position) < 0.1f) {
            movespot.position = new Vector3(UnityEngine.Random.Range(minX, maxX), 0, UnityEngine.Random.Range(minZ, maxZ));
        }
    }
    
    public override void ExitState()
    {
        Debug.Log("Exiting Patrolling state");
        Destroy(movespot.gameObject);
        Destroy(this);
    }
}
