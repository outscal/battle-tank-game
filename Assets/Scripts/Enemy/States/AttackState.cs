
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
        StartCoroutine(Fire());
    }

    IEnumerator Fire() {
        while (true)
        {
            Debug.Log("Shooting");
            GameObject obj = Shoot.Instance.Fire(firepoint);
            obj.layer = 13;
            yield return new WaitForSeconds(0.8f);
        }
    }
    public override void ExitState()
    {
        StopAllCoroutines();
        Debug.Log("Exiting Attacking state");
        Destroy(this);
    }
}
