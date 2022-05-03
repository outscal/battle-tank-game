using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankView))]
public class TankState : MonoBehaviour
{

    public TankView tankView;

    [SerializeField] protected Color color;
    protected virtual void Awake()
    {
        Debug.Log("Tank State Awake");
        tankView = GetComponent<TankView>();
    }
    public virtual void OnEnterState() 
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        this .enabled = false;
    }

    public virtual void Tick() { } //Update
}
