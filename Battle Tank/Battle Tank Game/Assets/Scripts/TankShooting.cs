using System;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int playerNumber = 1;
    public Rigidbody shell;
    public Transform fireTransform;
    public Slider aimSlider;
    public AudioSource shootingAudio;
    public AudioClip chargingClip;
    public AudioClip fireClip;
    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    private string fireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool isFired;

    private void OnEnable()
    {
        currentLaunchForce = minLaunchForce;
        aimSlider.value = minLaunchForce;
    }

    void Start()
    {
        fireButton = "Fire1";
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }
    
    void Update()
    {
        aimSlider.value = minLaunchForce;

        if(currentLaunchForce  >= maxLaunchForce && !isFired)
        {
           currentLaunchForce = maxLaunchForce;
           FireShell(); 
        }
        else if(Input.GetButtonDown(fireButton))
        {
            isFired = false;
            currentLaunchForce = minLaunchForce;
            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        else if(Input.GetButton(fireButton) && !isFired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            aimSlider.value = currentLaunchForce;
        } 
        else if(Input.GetButtonUp(fireButton) && !isFired)
        {
            FireShell();            
        }


    }

    private void FireShell()
    {
        isFired = true;

        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        shellInstance.velocity = currentLaunchForce * fireTransform.forward;

        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentLaunchForce = minLaunchForce;

    }
}
