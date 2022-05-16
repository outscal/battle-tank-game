using System;
using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    public TankView tankView;
    public CameraControl cameraControl;
    private Rigidbody rb; 

    private bool isDead;
    private bool isFired;

    private float currentLaunchForce;
    private float chargeSpeed;
    private string fireButton = "Fire1";

    private float minLaunchForce = 15f;
    private float maxLaunchForce = 30f;
    private float maxChargeTime = 0.75f;

    public TankController(TankModel _tankModel, TankView _tankview) 
    {   
        tankModel = _tankModel;       
        tankView = GameObject.Instantiate<TankView>(_tankview);        
        rb = tankView.GetRigidBody();
        tankView.tankController = this;
        
        isDead = false;
        currentLaunchForce = minLaunchForce;
    }//end contructor

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    //method for tankmovement forward and backward
    public void GetInput()
    {
        //getting the input left and right
        tankModel.movementInput = Input.GetAxis("Vertical");
        tankModel.turnInput = Input.GetAxis("Horizontal");
    }

    //method for tank Movement
    internal void Movement()
    {
        TankMovement(tankModel.movementInput, tankModel.movementSpeed);
        TankRotation(tankModel.turnInput, tankModel.rotationSpeed);
    }

    public void TankMovement(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    //method for tank turn
    public void TankRotation(float rotation, float rotationSpeed)
    {   
        float tankTurn;
        if(tankModel.movementInput != 0)
        {
            tankTurn = tankModel.movementInput * tankModel.turnInput * tankModel.rotationSpeed * Time.deltaTime;
        }
        else
        {
            tankTurn = tankModel.turnInput * tankModel.rotationSpeed * Time.deltaTime;
        }
        Quaternion turnRotation = Quaternion.Euler(0f, tankTurn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    public void TakeDamage(float amount)
    {
        tankModel.tankHealth -= amount;
        tankView.SetHealthUI();

        if(tankModel.tankHealth <= 0f && !isDead)
        {
            tankView.BeforePlayerDeath();
        }
    }

    public void OnDeath()
    {
        isDead = true;

        tankView.explosionParticles.transform.position = tankView.transform.position;
        tankView.explosionParticles.gameObject.SetActive(true);

        tankView.explosionParticles.Play();
        tankView.explosionAudio.Play();

        tankView.gameObject.SetActive(false);

        GameManager.Instance.DestroyAllGameObjects();
    }

    //shooting bullet

    public void GetFireInput()
    {
        tankView.aimSlider.value = minLaunchForce;
        
        if(currentLaunchForce >= maxLaunchForce && !isFired)
        {
            currentLaunchForce = maxLaunchForce;
            FireShell();
        }
        else if(Input.GetButtonDown(fireButton))
        {
            isFired = false;
            currentLaunchForce = minLaunchForce;
            tankView.shootingAudio.clip = tankView.chargingClip;
            tankView.shootingAudio.Play();
        }
        else if(Input.GetButton(fireButton) && !isFired)
        {
            currentLaunchForce += (maxLaunchForce - minLaunchForce) / maxChargeTime * Time.deltaTime;
            tankView.aimSlider.value = currentLaunchForce;
        }
        else if(Input.GetButtonUp(fireButton) && !isFired)
        {
            FireShell();
        }
    }

    private void FireShell()
    {
        isFired = true;

        tankView.CreateShellInstance(currentLaunchForce);
        
        currentLaunchForce = minLaunchForce;
    }
}//end class
