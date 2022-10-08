using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TankServices
{
    public class UiService
    {
        private static UiService instance;
        int FiredBulletCount= 0;
        public static UiService Instance
        {
            get
            {
                if(instance==null)
                    instance = new UiService();
                return instance ;
            }
        }
        
    }
}

