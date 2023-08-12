using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;


public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; }

    public TankController(TankModel _tankModel, TankView _prefabTankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_prefabTankView,getRandPosInWorld(),Quaternion.identity);
        tankModel.getTankController(this);
        tankView.getTankController(this);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public void destroyTankDatas()
    {
        tankModel = null;
    }

    private Vector3 getRandPosInWorld()
    {
        return new Vector3(Random.Range(0, 30), 1f, Random.Range(0, 30));
    }

    public virtual void UpdateTank()
    {

    }
    public virtual void UpdateCollisionControls()
    {

    }
    public virtual void onBulletHit()
    {
        tankModel.health -= 20;
        if (tankModel.health < 0)
        {
            DestroyTank();
        }
    }

    public virtual void DestroyTank()
    {
        tankModel.died = true;
        if(tankView!= null)
        {
            tankView.startDestroyCoroutine(0.2f);
        }
        
    }

    public void Fire()
    {
        Vector3 bulletPosition = tankModel.shootertransform.position;
        Quaternion bulletRotation = tankModel.shootertransform.transform.rotation;
        TransformSet reqBulletTransform = new TransformSet(bulletPosition, bulletRotation, tankView.tankRb.velocity);

        TankService.Instance.ServiceLaunchBullet(tankModel.bulletType, reqBulletTransform);
    }

    public void fireAfterCooldown()
    {
        tankView.fireCoroutine(1f,tankModel.firing);
    }

    public void toggleAutoFiring()
    {
        tankModel.firing = !tankModel.firing;
    }

    public void stopFiring()
    {
        tankView.StopFiring();
    }

    
}


public enum Direction { front = 1 , back = -1};
