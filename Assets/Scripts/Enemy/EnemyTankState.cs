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
