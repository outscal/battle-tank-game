using System;
using UnityEngine;

public class TankController : SingletonDemo<TankController>
{
    [SerializeField] Joystick joystick;
    [SerializeField] float horizontal,vertical;
    [SerializeField] float moveSpeed;
    const float TURNSPEED=50f;
    private Rigidbody m_tankRigidbody;
    const string HORIZONTAL = "Horizontal1";
    const string VERTICAL = "Vertical1";
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private Transform m_bulletPos;
    [SerializeField] float bulletForce = 1000f;
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] Color color;
    void Start()
    {
        m_tankRigidbody = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        
        vertical = joystick.Vertical;

        PlayerMovement(horizontal, vertical);
    }
   
    private void PlayerMovement(float horizontal, float vertical)
    {
        //Move player oldway 
        /*  Vector3 position = transform.position;
          position.x += horizontal * speed * Time.deltaTime;
          position.y = 0;
          position.z += vertical * speed * Time.deltaTime;
          transform.position = position;

          Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
          float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
          if(targetAngle!=0)
              headOfTank.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);*/
       Vector3 Movement= transform.forward * vertical * moveSpeed * Time.deltaTime;
       m_tankRigidbody.AddForce(Movement);

       float turn = horizontal * TURNSPEED * Time.deltaTime;
       Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
       m_tankRigidbody.MoveRotation(m_tankRigidbody.rotation * turnRotation);
    }

    public void FireBullet()
    {
        //Debug.Log("Bullet at "+m_bulletPos.position);
        GameObject bullet = Instantiate(bulletPrefab, m_bulletPos.position, m_bulletPos.rotation);
        bullet.GetComponent<Renderer>().material.color = color;
        bullet.GetComponent<Rigidbody>().AddForce(m_bulletPos.forward* bulletForce);
        Destroy(bullet, 3f);
    }

    public void SetPlayerTank(TankScriptableObject tankScriptableObject)
    {
        gameObject.name = tankScriptableObject.name;
        moveSpeed = tankScriptableObject.Speed;
        health = tankScriptableObject.Health;
        damage = tankScriptableObject.Damage;
        bulletForce = tankScriptableObject.BulletScriptableObject.BulletForce;
        GameObject TankRenderers = gameObject.transform.GetChild(0).gameObject;
        string plColor = tankScriptableObject.TankColor.ToString();
        switch (plColor)
        {
            case "Blue":
                color = new Color32(20, 125, 248, 255);
                break;
            case "Red":
                color = new Color32(167, 22, 22, 255);
                break;
            case "Green":
                color = new Color32(57, 116, 57, 255);
                break;
            case "Yellow":
                color = new Color32(150, 154, 15, 255);
                break;
        }
        for (int i = 0; i < TankRenderers.transform.childCount; i++)
        {
            TankRenderers.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = color;
        } 
    }

}
