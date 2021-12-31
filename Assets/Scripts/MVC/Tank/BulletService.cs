using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class BulletService : MonoBehaviour
    {
        public BulletView BulletView;
        public BulletScriptableObject[] bulletConfigurations;

        private void Start()
        {
            BulletScriptableObject bulletScriptableObject = bulletConfigurations[Random.Range(0,2)];
            BulletModel model = new BulletModel(bulletScriptableObject);
            BulletController Bullet = new BulletController(model, BulletView);
        }

    }
}