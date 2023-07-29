using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : TankController
{
    public EnemyTankController(TankModel _tankModel, TankView _tankview) : base(_tankModel, _tankview) { }

    public override void UpdateAutoControls()
    {
        moveForward();
        throwRay();
    }

    public override void UpdateCollisionControls()
    {
        moveOpposite();
    }

    public void moveForward()
    {
        tankView.gameObject.transform.position += tankView.gameObject.transform.forward  * tankModel.speed * Time.deltaTime;
    }
    public void moveOpposite ()
    {
        //Quaternion rotateTowards = Quaternion.LookRotation(-1 * tankView.gameObject.transform.forward, Vector3.up);
        //Quaternion newQ = Quaternion.Euler(0, 90, 0);
        Quaternion newQ = Quaternion.Euler(tankView.gameObject.transform.rotation.eulerAngles+new Vector3(0,10,0));
        tankView.gameObject.transform.rotation = Quaternion.Lerp(tankView.gameObject.transform.rotation, newQ, 0.1f);
    }
    public void throwRay()
    {
        Ray ememyRay = new Ray(tankView.gameObject.transform.position,tankView.gameObject.transform.forward);
        RaycastHit raycastHit = new RaycastHit();
        if(Physics.Raycast(ememyRay,out raycastHit)){
            if (raycastHit.distance < 3f)
            {
                tankModel.speed = 0;
                moveOpposite();
            }
            else tankModel.speed = tankModel.defaultSpeed;
        }
    }
};
