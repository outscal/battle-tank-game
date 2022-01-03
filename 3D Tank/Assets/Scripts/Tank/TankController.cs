using ObserverPattern;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Pause;


//Summary//
//Script responsible for controlling the tank
//-Summary//
public class TankController : GenericSingleton<TankController>
{
    #region Public Variables
    public event Action Shoot = delegate { };
    public Transform shootPoint;
    //[HideInInspector]
    public int bulletCount = 0;
    [HideInInspector]
    public AchievementTypes type;
    [HideInInspector]
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
    public Image[] image;
    public float missileCooldown;
    public float attackCooldown;
    public bool inattackCooldown = false;
    public bool inmissileCooldown = false;
    public Button[] button;
    public bool isTankDead = false;
    public bool homingLaunched = false;
    #endregion

    #region Serialized Variables
    [SerializeField] Joystick[] joystick;
    [SerializeField] int moveSpeed = 40;
    [SerializeField] int turnSpeed = 180;
    [SerializeField] GameObject homing;
    [SerializeField] ParticleSystem particle;
    [SerializeField] Slider m_Slider;                             
    [SerializeField] Image m_FillImage;                           
    #endregion

    #region Private Variables
    private Rigidbody rb;
    private float horizontalMove;
    private float verticalMove;
    private int enemyAttack;
    private Color m_FullHealthColor = Color.green;
    private Color m_ZeroHealthColor = Color.red;
    #endregion
    public TankController(TankModel model,TankView tankprefab)  //Instantiating the tank prefab
    {
        Model = model;
        tankView = GameObject.Instantiate<TankView>(tankprefab);
    }

    public TankModel Model { get; }
    public TankView tankView { get; }


    private void Start()              //getting the required components
    {
        maxHealth = TankService.Instance.getController().Model.Health;
        enemyAttack = EnemyTankService.Instance.GetEnemyController().Model.Attack;

        currentHealth = maxHealth;
        image[0].fillAmount = 1;
        image[1].fillAmount = 1;
       

        rb = GetComponent<Rigidbody>();
        particle = FindObjectOfType<ParticleSystem>();

        joystick[0] = JoystickController.Instance.joystick1;
        joystick[1] = JoystickController.Instance.horizontalJoystick;
        joystick[2] = JoystickController.Instance.verticalJoystick;
    }

    private void Update()
    {
        SetHealthUI();
        if(PauseMenuController.Instance.state == GameStates.RunningState)
        {
            TakeInput();

            button[0].onClick.AddListener(ShootBullet);

            if (inattackCooldown)
            {
                image[0].fillAmount += 1 / attackCooldown * Time.deltaTime;
                if (image[0].fillAmount == 1)
                {
                    image[0].fillAmount = 1;
                    inattackCooldown = false;
                }
            }

            button[1].onClick.AddListener(SendHoming);

            if (inmissileCooldown)
            {
                image[1].fillAmount += 1 / missileCooldown * Time.deltaTime;
                if (image[1].fillAmount == 1)
                {
                    image[1].fillAmount = 1;
                    inmissileCooldown = false;
                }
            }
        } 
    }

    public void ShootBullet()
    {
        if(inattackCooldown == false)
        {
            BulletService.Instance.InitiateBullet1();
            inattackCooldown = true;
            image[0].fillAmount = 0;
            bulletCount += 1;
        }    
    }

    public void Test()
    {
        Shoot += AchievementManager.Instance.DisplayAchievements;
    }

    public void TakeDamage()
    {
        // Reduce current health by the amount of damage done.
        currentHealth -= enemyAttack;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (currentHealth <= 0f && !isTankDead)
        {
           // OnDeath();
            StartCoroutine(Death());
        }
    }

    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = currentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / maxHealth);
    }

    public void BulletCount()
    {
        if (bulletCount == 10)
        {
            Test();
            Shoot.Invoke();
            type = AchievementTypes.AmateurShooter;
        }
        else if (bulletCount == 25)
        {
            Test();
            Shoot.Invoke();
            type = AchievementTypes.SharpShooter;
        }
        else if (bulletCount == 50)
        {
            Test();
            Shoot.Invoke();
            type = AchievementTypes.DeadShooter;
        }
    }

    public void SendHoming()
    {
        if(inmissileCooldown == false)
        {
            homingLaunched = true;
            Instantiate(homing, shootPoint);
            inmissileCooldown = true;
            image[1].fillAmount = 0;
        }
    }

    private void TakeInput()
    {
        if (JoystickController.Instance.joystick1_isActive)
        {   
            horizontalMove = joystick[0].Horizontal;
            verticalMove = joystick[0].Vertical;
        }
        else if (JoystickController.Instance.joystick1_isActive == false)
        {
            horizontalMove = joystick[1].Horizontal;
            verticalMove = joystick[2].Vertical;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()  //Method to move the tank prefab
    {
        Vector3 movement = transform.forward * verticalMove * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()  //Method to turn the Tank prefab
    {
        float turn = horizontalMove * turnSpeed * Time.deltaTime;
        if(Mathf.Abs(turn) > 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    public IEnumerator Death()    //Method for destruction of tank prefab
    {
        isTankDead = true;
        particle.transform.parent = null;
        particle.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        DestroyLevel.Instance.DestroyAll();
    }
}
