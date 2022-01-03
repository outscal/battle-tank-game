using UnityEngine;

public class AttackState : States
{
    #region Public Variables

    public PatrolState patrol;
    public ChaseState chase;
    public bool alreadyAttacked;
    public float timeBetweenAttacks;
    public Transform player;
    public Transform turret;
    public GameObject bullet;
    public Transform shootpoint;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public override States RunCurrentState()
    {
        if (patrol.playerInAttackRange == false && patrol.playerInSightRange)
        {
            return chase;
        }
        if (patrol.playerInAttackRange)
        {
            AttackPlayer();
        }
        return this;
    }

    public void AttackPlayer()
    {
        FaceTarget();
        
        if (!alreadyAttacked)
        {
            //BulletService.Instance.InitiateBullet2();
            Instantiate(bullet, shootpoint.transform);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    void FaceTarget() 
    {
        Vector3 direction = (player.position - turret.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
