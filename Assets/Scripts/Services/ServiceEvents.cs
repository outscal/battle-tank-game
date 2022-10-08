using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TankServices
{
    public class ServiceEvents
    {
        private static ServiceEvents instance;

        public static ServiceEvents Instance
        {
            get {
                if (instance == null)
                    instance = new ServiceEvents();
                return instance;
            }
        }

        public Action<int> OnShoot ;
        public Action<bool> OnPlayerDeath ;
    }

}

