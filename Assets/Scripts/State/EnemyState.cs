using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;
using TankGame.Tank;

[RequireComponent(typeof(EnemyView))]
public class EnemyState : MonoBehaviour
{
    protected EnemyView enemyView;
    [SerializeField]
    protected Color changedColor;
    //protected TankView targetPlayer;

    private void Awake()
    {
        enemyView = GetComponent<EnemyView>();
        //targetPlayer = TankService.Instance.GetCurrentPlayer();
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }

    //public virtual void Tick() //Update
    //{

    //}
}
 