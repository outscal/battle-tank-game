using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{   
    [SerializeField]
    private Joystick joystick;

    #region PRIVATE METHODS

        private void Start() {
            
        }

        
        private void FixedUpdate() {

            float vertical = joystick.Vertical;
            float horizontal = joystick.Horizontal;
            moveTankAround(vertical,horizontal);
        }

        private void moveTankAround(float vertical,float horizontal){
            Vector3 movement = new Vector3(horizontal, 0.0f,vertical);
            
            if(movement != Vector3.zero){
                transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),1f);
            }

            transform.Translate(Speed*horizontal*Time.deltaTime,
                                0f,Speed*vertical*Time.deltaTime,
                                Space.World);
        }


    #endregion



    #region PUBLIC METHODS
        
        public TankController(TankScriptableObject tankScriptableObject){
            Speed = tankScriptableObject.Speed;
            Health = tankScriptableObject.Health;
            tankType = tankScriptableObject.tankType;
        }

        #region GETTERS|SETTERS

            public int Speed{get;private set;}
            public int Health{get;private set;}
            public TankType tankType{get;private set;}

        #endregion

    #endregion


}
