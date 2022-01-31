using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tankServices
{
public class TankService : TankSingeton<TankService>
{
        private PlayerTankController playerTankController;
        [SerializeField]private PlayerTankView playerTankView;

        private void Start()
        {
            CreateTank();
        }

         public  void CreateTank()
        {
            PlayerTankModel PlayertankModel = new PlayerTankModel();
            playerTankController = new PlayerTankController(PlayertankModel,playerTankView);
        }
    }

}