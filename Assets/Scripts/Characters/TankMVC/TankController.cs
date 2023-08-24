using System;
using UnityEngine;

public class TankController 
{
    public TankModel PlayerModel { get; private set; }
    public TankView PlayerView { get; private set; }
    private Rigidbody playerRigidBody;
    private Transform playerTransform;
    public TankController(TankModel _playerModel, TankView _playerView)
    {
        PlayerView = _playerView;
        PlayerModel = _playerModel;
        PlayerView.SetTankController(this);
        GetReferences();
    }
    private void GetReferences()
    {
        playerTransform = PlayerView.transform;
        playerRigidBody = PlayerView.GetPlayerRigidBody();
    }
    public void Move(float vertical)
    {
        float moveSpeed = PlayerModel.Speed;
        playerRigidBody.AddRelativeForce(Vector3.forward * moveSpeed * vertical);
    }
    public void Rotate(float horizontal)
    {
        float turnSpeed = PlayerModel.Rotationspeed;
        playerTransform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
    }
    public GameObject GetGameObject()
    {
        return PlayerView.gameObject;
    }
    public int GiveDamage()
    {
        return PlayerModel.Damage;
    }
    public void TakeDamage(int damage)
    {
        int health = PlayerModel.Health - damage;
        health = health >= 0 ? health : 0;
        PlayerModel.SetHealth(health);

        if (health == 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Player Dead");
    }

}
