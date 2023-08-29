using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    private TankModel tankModel;
    void Start()
    {
        Destroy(this.gameObject,1f);  
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {

    //     TankView tankView = collision.gameObject.GetComponent<TankView>();
    //     if (collision.gameObject.GetComponent<TankView>() != null)
    //     {
    //         tankModel.Health -= 1;
    //         tankView.KillPlayer();
            
    //         if(UI_Manager.health < 1){
    //             tankView.Dead();
    //         }
    //     }
            
    // }

}
