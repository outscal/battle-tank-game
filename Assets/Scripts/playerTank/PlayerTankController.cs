using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tankServices
{
public class PlayerTankController 
{
        public PlayerTankModel playerTankModel { get; private set; }
        public  PlayerTankView playerTankView { get; private set; }
       
        
        //constructor
        public PlayerTankController(PlayerTankModel _playerTankModel , PlayerTankView _PLayerTankView)
        {
            playerTankModel = _playerTankModel;
            //playerTankView = GameObject.Instantiate<PlayerTankView>(_PLayerTankView);
            playerTankView = _PLayerTankView;
            playerTankView.setController(this);
            playerTankModel.SetController(this);

        }


        public void move(float straight , float turn)
        {
            Debug.Log(straight +"  " +turn);
            //playerTankView.gameObject.transform.position += new Vector3(turn, 0, straight) * Time.fixedDeltaTime*playerTankModel.movementSpeed;
            playerTankView.transform.position += new Vector3(turn, 0, straight) * Time.fixedDeltaTime*playerTankModel.movementSpeed;
           
            
        }
    }
}