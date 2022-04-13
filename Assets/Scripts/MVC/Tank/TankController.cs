using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel TankModel { get; }
    public TankView TankView { get; set; }
    private Joystick rightJoystick;
    private Joystick leftJoystick;
    private Rigidbody rbTank;
    private Camera camera;
    float byDefaultHealth;

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        rbTank = TankView.GetComponent<Rigidbody>();
    }

    public void SetCamera(Camera cameraSet)
    {
        camera = cameraSet;
        camera.transform.SetParent(TankView.Turret.transform);
    }

    public void SetJoystick(Joystick rtJoystick, Joystick ltJoystick)
    {
        rightJoystick = rtJoystick;
        leftJoystick = ltJoystick;
    }

    public void SetHealthUI()
    {
        TankView.healthSlider.value = TankModel.Health;
        TankView.healthFillImage.color = Color.Lerp(TankView.minHealthColour, TankView.maxHealthColour, TankModel.Health / byDefaultHealth);
    }

    public void TakeDamage(int damage)
    {
        byDefaultHealth = TankModel.Health;
        TankModel.Health -= damage;
        SetHealthUI();
        if (TankModel.Health <= 0f && !TankView.isTankLive)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        TankView.isTankLive = true;
        TankView.explosionParticles.transform.position = TankView.transform.position;
        TankView.explosionParticles.gameObject.SetActive(true);
        TankView.explosionParticles.Play();
        TankView.explosionSound.Play();
        camera.transform.parent = null;
        TankView.DestroyTank();
        DestroyGameObjects();
    }

    public void DestroyGameObjects()
    {
        DestroyEnemyObjects();
        DestroyGroundObjects();

    }

    private async void DestroyEnemyObjects()
    {
        //await new WaitForSeconds(2f);
        GameObject enemyTank = GameObject.FindGameObjectWithTag("EnemyTank");
        enemyTank.GetComponent<EnemyTankView>().enemyTankController.OnEnemyDeath();
    }

    private async void DestroyGroundObjects()
    {
        //await new WaitForSeconds(3f);
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");
        DestroyGround(ground);
        //await new WaitForSeconds(0.05f);

    }

    private void DestroyGround(GameObject gameObject)
    {
        TankView.DestroyGround(gameObject);
    }

    public void UpdateShootBullet()
    {
        BulletService.Instance.CreateBullet(TankView.BulletEmitter);
    }

    public void FixedUpdateTankController()
    {
        if (rbTank)
        {
            if (leftJoystick.Vertical != 0)
            {
                ForwardMovement();
            }
            if (leftJoystick.Horizontal != 0)
            {
                RotationMovement();
            }
        }

        if (true)
        {
            if (rightJoystick.Horizontal != 0)
            {
                TurretRotationMovement();
            }
        }

    }

    private void TurretRotationMovement()
    {
        Vector3 turrentrotation = Vector3.up * rightJoystick.Horizontal * TankModel.TurretRotationRate * Time.deltaTime;

        TankView.Turret.transform.Rotate(turrentrotation, Space.Self);
    }

    private void RotationMovement()
    {
        Quaternion rotation = rbTank.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * TankModel.RotationRate * Time.deltaTime);

        rbTank.MoveRotation(rotation);
    }

    private void ForwardMovement()
    {
        Vector3 moveforward = rbTank.transform.position + (leftJoystick.Vertical * rbTank.transform.forward * TankModel.Speed * Time.deltaTime);
        rbTank.MovePosition(moveforward);
    }
}