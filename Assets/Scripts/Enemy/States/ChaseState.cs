using UnityEngine;

public class ChaseState : State
{
    public EnemyController ec;
    private Transform target;
    private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        speed = 10f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    public override void EnterState()
    {
        Debug.Log("Chasing Protag");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            ec.transform.position = Vector3.MoveTowards(ec.transform.position, target.position, speed * Time.deltaTime);
            ec.transform.LookAt(target);
        }
    }
    public override void ExitState()
    {
        Debug.Log("Leaving chasing state");
    }
}
