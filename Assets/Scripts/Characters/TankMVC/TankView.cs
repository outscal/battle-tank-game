using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private ParticleSystem tankExplosion;
    [SerializeField] private Transform shootPoint;

    private TankController playerController;
    private BulletServices bulletServices;
    private int bulletCount = 0;
    private float verticalInput;
    private float horizontalInput;
    private bool fireInput = false;
    
    public Rigidbody GetPlayerRigidBody()
    {
        return this.playerRigidBody;
    }
    public Transform GetshootPoint()
    {
        return this.shootPoint;
    }

    public int GetHealth()
    {
        return playerController.PlayerModel.Health;
    }
    public void SetTankController(TankController tankController)
    {
        playerController = tankController;
    }
    private void Update()
    {
        HandleInputs();

        playerController.Rotate(horizontalInput);
        if (fireInput)
        {
            bulletServices.Shoot(shootPoint,this.gameObject);
            bulletCount++;

        }
    }
    private void FixedUpdate()
    {
        playerController.Move(verticalInput);
    }
    private void HandleInputs()
    {
        fireInput = Input.GetKeyDown(KeyCode.Space);
        verticalInput = Input.GetAxis("Vertical1");
        horizontalInput = Input.GetAxis("Horizontal1");
    }

    public void TakeDamageview(int Damage)
    {
        playerController.TakeDamage(Damage);
        throw new NotImplementedException();
    }

    internal void SetBulletService(BulletServices _bulletservices)
    {
        bulletServices = _bulletservices;
    }
}
