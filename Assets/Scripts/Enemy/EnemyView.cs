using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
    public class EnemyView : MonoBehaviour
    {
        EnemyController enemyController;

        internal void Initialize(EnemyController controller)
        {
            enemyController = controller;
        }
    }
}
