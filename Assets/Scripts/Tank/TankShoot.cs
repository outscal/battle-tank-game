using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankShoot : MonoBehaviour
{

    [SerializeField]ObjectPool objectPool;

    public Transform m_FireTransform;           
    public float m_MinLaunchForce = 15f;        
    public float m_MaxLaunchForce = 30f;        
    public float m_MaxChargeTime = 0.75f;       

    private float m_CurrentLaunchForce;         
    private float m_ChargeSpeed;                
    private bool m_Fired;
    //private bool isReloading=false;
    //private Coroutine Reload;

//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Start ()
    { 
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;                                 //speed of charge depends on MaxCharge time
    }

//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Update ()
    {
 
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)                                               //if currentforce exceeds MaxForce
        {
            
            m_CurrentLaunchForce = m_MaxLaunchForce;                                                            // launch Shell with max force
            Fire ();
        }
       
        else if (Input.GetButtonDown ("Fire"))                                                                   // if the fire button is just pressed
        {
            m_Fired = false;                                                                                    //reset the fired flag and reset/set the launch force.
            m_CurrentLaunchForce = m_MinLaunchForce;
        }
        
        else if (Input.GetButton ("Fire") && !m_Fired)                                                          //fire button is held,the shell hasn't been launched 
        {
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;                                             //Increment the launch force.
        }
        
        else if (Input.GetButtonUp ("Fire") && !m_Fired)                                                        //fire button is released,shell hasn't been launched
        {
            Fire ();
        }
    }

//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Fire ()
    {
        //if(!isReloading){
            //isReloading = true;
            m_Fired = true;                                                                                     // Set the fired flag so Fire is only called once.
            Rigidbody shellInstance = (objectPool.spawner("Shell",m_FireTransform)).GetComponent<Rigidbody>();  //get Rigidbody Component from Object Instance
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;                            // Set the shell's velocity 
        //}

        // if(Reload==null){
        //     Reload = StartCoroutine(ReloadShell());
        // }
        // else{
        //     Debug.Log("Wait for reload");
        // }
        
    }

//```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````````````````````````Reload Mechanics

    // private IEnumerator ReloadShell(){
    //     Debug.Log("Reloading");
    //     yield return new WaitForSeconds(5);
    //     isReloading = false;
    //     Reload = null;
    // }

}