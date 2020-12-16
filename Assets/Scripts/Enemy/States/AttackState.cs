
using System.Collections;
using UnityEngine;

public class AttackState : State
{
   
    private EnemyController ec;
    private Transform firepoint;

    public override void EnterState()
    {
        Transform[] tr = gameObject.GetComponentsInChildren<Transform>();
        firepoint = tr[tr.Length - 1];

        Debug.Log("Entering attack state");
       
    }
    private void Update()
    {
        if (attackCD <= 0)
        {
           // Fire();
            attackCD = 1f;
        }
        else
        {
            attackCD -= Time.deltaTime;
            //Debug.Log("Attack CD - " + attackCD +"  dt -" +Time.deltaTime);
        }
    }
    void Fire() {
            Debug.Log("Shooting");
            GameObject obj = Shoot.Instance.Fire(firepoint);
            obj.layer = 13;
    }
    public override void ExitState()
    {
        Debug.Log("Exiting Attacking state");
    }
}
