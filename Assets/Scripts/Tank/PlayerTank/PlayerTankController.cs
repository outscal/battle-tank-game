
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerTankController 
{
    public PlayerTankModel TankModel { get; }
    public PlayerTankView TankView { get; }

    private Rigidbody tankRigidBoy;



    public PlayerTankController(PlayerTankModel _tankModel, PlayerTankView _tankView, Vector3 pos)
    {
        TankModel = _tankModel;
        TankView = GameObject.Instantiate<PlayerTankView>(_tankView,pos,_tankView.transform.rotation);
        
        TankView.SetTankController(this);
    }

    public void SetRigidBody(Rigidbody rb)
    {
        tankRigidBoy = rb;
    }

    public void MoveTank(float _move)
    {
        tankRigidBoy.velocity = _move * TankModel.MovementSpeed * Time.deltaTime * TankView.transform.forward;
    }

    public void RotateTank(float _rotation)
    {
        Vector3 rotate = new (0f,_rotation * TankModel.RotationSpeed,0f);
        Quaternion deltaRotaion = Quaternion.Euler(rotate * Time.deltaTime);
        tankRigidBoy.MoveRotation(tankRigidBoy.rotation * deltaRotaion);
    }

    public void TakeDamage(BulletView bullet)
    {
        TankModel.Health -= bullet.BulletModel.Power;
        if (TankModel.Health <= 0)
        {
            PlayerDead();
        }
    }
    public void PlayerDead()
    {
        DestoryEverything.Instance.PlayerTank = TankView;
        DestoryEverything.Instance.DestroyEverythingInGame();
    }
    public void FireBullet(Vector3 pos)
    {
        BulletService.Instance.GenerateBullet(pos,TankView.transform.rotation);
        BulletService.Instance.OnPlayerBulletFire?.Invoke();
    }

}
