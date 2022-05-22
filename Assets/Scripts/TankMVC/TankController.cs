using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This Class implements all the logic which is required for a Tank Entity in the game to Operate as required.
/// </summary>
public class TankController
{
    private Joystick LeftJoyStick;
    private Joystick RightJoyStick;
    private float SpeedMultipier = 0.001f;
    private float RotationSpeedMultiplier = 0.01f;
    //private Image healthBar;
    private float lerpSpeed;
    //public TankView tankView;
    //private Camera camera;
    private ShellExplosion ShellExplosion;


    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }

    // Sets the reference to left & right Joysticks on the Canvas.
    public void SetJoyStickReferences(Joystick leftJoyStick, Joystick rightJoyStick)
    {
        LeftJoyStick = leftJoyStick;
        RightJoyStick = rightJoyStick;
    }

    // Sets the reference to the Camera & makes it a child object of PLayer Tank.
    // public void SetCameraReference(Camera cameraRef)
    //{
    // camera = cameraRef;
    //camera.transform.SetParent(TankView.transform);
    //}

    // This Function Handles the Input from the Left Joystick.
    public void HandleLeftJoyStickInput(Rigidbody tankRigidBody)
    {
        if (LeftJoyStick.Vertical != 0)
        {
            Vector3 ZAxisMovement = tankRigidBody.transform.position + (tankRigidBody.transform.forward * LeftJoyStick.Vertical * TankModel.Speed * SpeedMultipier);
            tankRigidBody.MovePosition(ZAxisMovement);
        }

        if (LeftJoyStick.Horizontal != 0)
        {
            Quaternion newRotation = tankRigidBody.transform.rotation * Quaternion.Euler(Vector3.up * LeftJoyStick.Horizontal * TankModel.RotationSpeed * RotationSpeedMultiplier);
            tankRigidBody.MoveRotation(newRotation);
        }
    }

    // This Function Handles the Input recieved from the Right Joystick.
    public void HandleRightJoyStickInput(Transform turretTransform)
    {
        Vector3 desiredRotation = Vector3.up * RightJoyStick.Horizontal * TankModel.TurretRotationSpeed * RotationSpeedMultiplier;
        turretTransform.Rotate(desiredRotation, Space.Self);
    }

    
    //public void TakeDamage(float amount)
    //{
    //    TankModel.currentHealth -= amount;

    //    if (TankModel.currentHealth <= 0f && TankView.tankDead)
    //    {
    //        TankModel.currentHealth = 0;
    //        SetHealthUI();
    //        TankDestroy();
    //        return;
    //    }
    //    Debug.Log("Player Took Damage " + TankModel.currentHealth);
    //    SetHealthUI();
    //}

    public void TakeDamage(float amount)
    {
        TankModel.currentHealth -= amount;
        SetHealthUI();

        if (TankModel.currentHealth <= 0f && !TankView.tankDead)
        {
            TankDestroy();
        }
    }
    private void TankDestroy()
    {
        //TankView.tankDead = true;
        //TankView.gameObject.SetActive(false);
        //TankView.Destroy(TankView.gameObject);
        TankView.tankDead = true;
        ShellExplosion.m_ExplosionParticles.transform.position = ShellExplosion.transform.position;
        ShellExplosion.m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        ShellExplosion.m_ExplosionParticles.Play();

        // Play the tank explosion sound effect.
        ShellExplosion.m_ExplosionAudio.Play();

        // Turn the tank off.
        ShellExplosion.gameObject.SetActive(false);

        ShellExplosion.Destroy(ShellExplosion.gameObject);

    }
    public void OnEnableFunction()
    {
        lerpSpeed = 3f * Time.deltaTime;
        TankModel.CurrentLaunchForce = TankModel.MinLaunchForce;
        //TankView.aimSlider.value = TankModel.MinLaunchForce;
        TankModel.currentHealth = TankModel.Health;
        TankView.tankDead = false;
        //SetHealthUI();
    }

    
    public void SetHealthUI()
    {
        Debug.Log("color");
        //TankView.sliderHealth.value = TankModel.currentHealth;
        //TankView.fillImage.color = Color.Lerp(TankView.zeroHealthColor, TankView.fullHealthColor, TankModel.currentHealth / TankModel.Health);

        
        TankView.healthBar.fillAmount = Mathf.Lerp(TankView.healthBar.fillAmount, TankModel.currentHealth / TankModel.Health, lerpSpeed);
        Color HealthColor = Color.Lerp(Color.red, Color.green, (TankModel.currentHealth / TankModel.Health));
        TankView.healthBar.color = HealthColor;

    }

    public Transform GetTransform()
    {
        return TankView.transform;
    }
    
}