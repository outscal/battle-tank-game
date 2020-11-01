using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankModel tankModel;

    [SerializeField]
    private TankController tankController;

    private void Update() {
        Vector3 movement = new Vector3(tankController.horizontal, 0.0f,tankController.vertical);
        
        if(movement != Vector3.zero){
            transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),0.05f);
        }

        transform.Translate(tankModel.getSpeed()*tankController.horizontal*Time.deltaTime,
                            0f,tankModel.getSpeed()*tankController.vertical*Time.deltaTime,
                            Space.World);

        Debug.Log("Speed in TankView = " + tankModel.getSpeed());
    }
}
