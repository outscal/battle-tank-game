using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    
    
    
    [SerializeField]
    private int Speed;
    [SerializeField]
    private int Health;
    [SerializeField]
    private TankType tanktype;
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
            transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),0.05f);
        }

        transform.Translate(Speed*horizontal*Time.deltaTime,
                            0f,Speed*vertical*Time.deltaTime,
                            Space.World);
    }


    #endregion



    #region PUBLIC METHODS
        
        public TankController(int speed,int health,TankType tankType){
            Speed = speed;
            Health = health;
            tanktype = tankType;
        }


    #endregion


}
