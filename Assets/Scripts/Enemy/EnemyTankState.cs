using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankState : MonoBehaviour
{
    public virtual void OnEnterState(){
        this.enabled = true;
    } 

    public virtual void OnExitState(){
        this.enabled = false;
    }
    
}
