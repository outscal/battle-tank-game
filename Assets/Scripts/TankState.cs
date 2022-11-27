using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(TankView))]
public class TankState : MonoBehaviour
{
    protected TankView tankView;

    [SerializeField]
    protected Color color;
    
    protected virtual void Awake()
    {
        tankView = GetComponent<TankView>();
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
    
    }
    public virtual void OnEXitState()
    {
        this.enabled = false;   
    }

    /*public virtual void Tick()
    {

    }*/
}
