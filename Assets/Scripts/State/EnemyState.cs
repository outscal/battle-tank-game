using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;
using TankGame.Tank;

//[RequireComponent(typeof(EnemyView))]
public class EnemyState : MonoBehaviour
{

    public EnemyView enemyView;
    [SerializeField]
    protected Color changedColor;
    //protected TankView targetPlayer;

    //protected TankView targetPlayer;

    private void Awake()
    {
        //targetPlayer = TankService.Instance.GetCurrentPlayer();
    }

    private void Start()
    {
        //enemyView = GetComponent<EnemyView>();
        
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
        enemyView.SetTankColor(changedColor);
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }

    //public virtual void Tick() //Update
    //{

    //}
}
 