using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is attached to the Bullet Game Object in the game.
/// </summary>

public class BulletView : MonoBehaviour
{
    BulletController bulletController;

    public void Initialize(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}
