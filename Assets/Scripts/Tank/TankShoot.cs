using UnityEngine;
using UnityEngine.UI;

public class TankShoot : MonoBehaviour
{

    [SerializeField]ObjectPool objectPool;

    //public Rigidbody m_Shell;                   
    public Transform m_FireTransform;           
    public float m_MinLaunchForce = 15f;        
    public float m_MaxLaunchForce = 30f;        
    public float m_MaxChargeTime = 0.75f;       


    private float m_CurrentLaunchForce;         
    private float m_ChargeSpeed;                
    private bool m_Fired;                       


    private void Start ()
    {
        // speed of charge depends on max charge time
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update ()
    {

        // If the max force has been exceeded and the shell hasn't yet been launched...
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            // launch Shell with max force
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire ();
        }
        // if the fire button has just pressed
        else if (Input.GetButtonDown ("Fire"))
        {
            // ... reset the fired flag and reset/set the launch force.
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

        }
        // if the fire button is being held and the shell hasn't been launched yet...
        else if (Input.GetButton ("Fire") && !m_Fired)
        {
            // Increment the launch force.
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

        }
        // if the fire button is released and the shell hasn't been launched yet...
        else if (Input.GetButtonUp ("Fire") && !m_Fired)
        {
            // ... launch the shell.
            Fire ();
        }
    }


    private void Fire ()
    {
        // Set the fired flag so Fire is only called once.
        m_Fired = true;

        Rigidbody shellInstance = (objectPool.spawner("shell",m_FireTransform)).GetComponent<Rigidbody>();
        // Set the shell's velocity 
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;
    }
}