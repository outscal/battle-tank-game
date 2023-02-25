// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class firesc : MonoBehaviour
// {
//     public Rigidbody shell;
//     public Transform spawn;
//     public Button fired;
//     public Slider  aimSlider;
//     //take below from bullet object or tank object
//     public float minLaunchForce = 15f;
//     public float maxLaunchForce = 30f;
//     public float maxChargeTime = .75f;
//     private float currentLaunchForce;
//     private float chargeSpeed;
//     private bool Fired;
//     private void OnEnable() 
//     {
//         currentLaunchForce = minLaunchForce;
//         aimSlider.value = minLaunchForce; 
//     }
//     void Start()
//     {
//         chargeSpeed = (maxLaunchForce - minLaunchForce)/maxChargeTime;
//     }
//     void Update()
//     {
//         aimSlider.value = minLaunchForce;
//         if(currentLaunchForce >=maxLaunchForce && !Fired)
//         {
//             currentLaunchForce = maxLaunchForce;
//             Fire();
//         }
//         else if (Input.GetButtonDown("fire"))
//         {
//             Fired = false;
//             currentLaunchForce = minLaunchForce;
//         }
//         else if (Input.GetButton("fire") && !Fired)
//         {
//             currentLaunchForce += chargeSpeed * Time.deltaTime;
//             aimSlider.value = currentLaunchForce;
//         }
//         else if (Input.GetButtonUp("fire") && !Fired)
//         {
//             Fire();
//         }
//     }
//     private void Fire() {
//         {
//             Fired = true;
//             BulletSpawner bullet ;
//             bullet.Spawn(currentLaunchForce);
//             currentLaunchForce = minLaunchForce;
//         }
//     }
// }
