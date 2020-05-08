//using System.Collections;
//using System.Collections.Generic;
using Tank.Service;
//using Tank.View;
using UnityEngine;

namespace Camera.FollowPlayer
{
    public class FollowPlayer : MonoBehaviour
    {
        private void Update()
        {
            transform.position = TankService.Instance.TankController.TankView.transform.position;
        }
    }
}
