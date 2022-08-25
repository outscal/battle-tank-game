using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is attached to the Bullet Game Object in the game.
/// </summary>

namespace BulletServices
{
    // Script is present on visual instance of bullet.
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        BulletController bulletController;

        // To set bullet controller reference in bullet view.
        public void BulletInitialize(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}
