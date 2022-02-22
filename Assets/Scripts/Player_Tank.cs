using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Tank : Singleton_Generic<Player_Tank>
{
    public Joystick Tank_joystick;
    float horizontalInput, verticalInput, speed, rotationSpeed, joystick_minMovement;
    public float maxHealth;
    public float currentHealth;
    public Slider healthBar;
    public Image m_FillImage;

    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    private bool m_Dead;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        speed = 6.0f;
        rotationSpeed = 250.0f;
        joystick_minMovement = 0.5f;
    }

    private void Update()
    {
        Tank_Movement();
    }

    void Tank_Movement()
    {
        horizontalInput = Tank_joystick.Horizontal * 5;
        verticalInput = Tank_joystick.Vertical * 5;

        if (horizontalInput > joystick_minMovement || horizontalInput < -joystick_minMovement || verticalInput > joystick_minMovement || verticalInput < -joystick_minMovement)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            moveDirection.Normalize();

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        currentHealth = maxHealth;
        m_Dead = false;

        // Update the health slider's value and color.
        SetHealthUI();
    }


    public void Tank_Damage(float amount)
    {


        // Reduce current health by the amount of damage done.
        currentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (currentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }

        Debug.Log("Tank Damaged");
    }
    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        healthBar.value = currentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / maxHealth);
    }
    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        m_Dead = true;

        // Turn the tank off.
        gameObject.SetActive(false);
    }
}

