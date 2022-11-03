using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TankServices
{
    public class ServiceEvents: GenricSingleton<ServiceEvents>
    {
        public Action<int> OnShoot;
        public Action OnPlayerDeath;
        public Action ChasePlayer;
        public Action StopChase;
    }

}

