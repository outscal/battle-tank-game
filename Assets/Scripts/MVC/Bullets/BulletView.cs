using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        [SerializeField] private BulletType bulletType;
        void Start()
        {
            Debug.Log("bullet view created");
        }
    }
}