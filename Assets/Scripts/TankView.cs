using System;
using System.Collections;
using System.Collections.Generic;
using Tanks.Tank;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image), typeof(Rigidbody))]
public class TankView:MonoBehaviour, IDamagable 
{

    public TankType type;
    private TankControllerScript tankController;
    private Image image;

    private TankState currentState;
    public TankPatrolingState petrolingstate;

    internal void ChangeState(TankChasingState chasingState)
    {
        throw new NotImplementedException();
    }

    public TankChasingState chasingState;
    public TankState startingstate;

   
    private void Start()
    {
        //ChangeState(startingstate);
        ChangeState(petrolingstate);
    }
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void TakeDamage(BulletType bulletType, int damage)
    {
        tankController.ApplyDamage(bulletType, damage);
        Debug.Log("Taking Damage"+damage+"from bullet"+bulletType);

    }

    public void Initialise(TankControllerScript tankController)
    {
        this.tankController = tankController;

    }

    public void ChangeColor(Color color)
    {
        //c = color.r;
        image.color = color;
    }

    public void ChangeState(TankState newState)
    {

        if (currentState!=null)
        {
            currentState.OnEXitState();
        }

        currentState = newState;
        currentState.OnEnterState();

    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
