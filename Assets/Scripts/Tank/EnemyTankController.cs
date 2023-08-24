using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyTankController : TankController
{
    public EnemyTankController(TankModel _tankModel, TankView _tankview) : base(_tankModel, _tankview) 
    {

        tankModel.currentState = new StatePatrolling(this);
    }
   
    public override void UpdateTank()
    {
        tankModel.currentState.onTick();
    }

    public override void UpdateCollisionControls()
    {
        tankModel.currentState.onCollision();
    }

    public override void DestroyTank()
    {
        base.DestroyTank();
        if (TankService.Instance.playerTankController!=null) TankService.Instance.killIncrementer();
    }

    public void changeState(TankState _tanksState)
    {
        if(_tanksState != null)
        {
            tankModel.currentState = _tanksState;
            tankModel.currentState.onStateEnter();
        }
        else
        {
            tankModel.currentState = _tanksState;
            tankModel.currentState.onStateEnter();

        }
    }
    public void moveForward()
    {
        tankView.gameObject.transform.position += tankView.gameObject.transform.forward  * tankModel.speed * Time.deltaTime;
    }
    public void shiftDirectionSlow ()
    {
        //Quaternion rotateTowards = Quaternion.LookRotation(-1 * tankView.gameObject.transform.forward, Vector3.up);
        //Quaternion newQ = Quaternion.Euler(0, 90, 0);
        Quaternion newQ = Quaternion.Euler(tankView.gameObject.transform.rotation.eulerAngles+new Vector3(0,10,0));
        tankView.gameObject.transform.rotation = Quaternion.Lerp(tankView.gameObject.transform.rotation, newQ, 0.1f);
    }

    public float distanceBtwPlayer()
    {
        TankController player = TankService.Instance.playerTankController;
        if (player != null)
        {
            Vector3 selfPosition = tankView.gameObject.transform.position;
            Vector3 targetPosition = player.tankView.gameObject.transform.position;
            return Vector3.Distance(selfPosition, targetPosition);
        }
        return 100f;
        
    }

    public void throwRay()
    {
        Ray ememyRay = new Ray(tankView.gameObject.transform.position,tankView.gameObject.transform.forward);
        RaycastHit raycastHit = new RaycastHit();
        if(Physics.Raycast(ememyRay,out raycastHit)){
            if (raycastHit.distance < 3f)
            {
                tankModel.speed = 0;
                shiftDirectionSlow();
            }
            else tankModel.speed = tankModel.defaultSpeed;
        }
    }

    public void lookAtPlayer()
    {
        TankController player = TankService.Instance.playerTankController;
        if (player != null)
        {
            /*float angleToLook = Vector3.Angle(tankView.gameObject.transform.forward.normalized, (tankView.gameObject.transform.position - player.tankView.gameObject.transform.position).normalized);
            Quaternion lookingRotation = Quaternion.AngleAxis(360-angleToLook, Vector3.up);
            tankView.gameObject.transform.rotation = Quaternion.Lerp(tankView.gameObject.transform.rotation, lookingRotation, 0.1f);*/
            tankView.gameObject.transform.LookAt(player.tankView.gameObject.transform.position);
        }
    }

    public override void onBulletHit()
    {
        base.onBulletHit();

    }

}