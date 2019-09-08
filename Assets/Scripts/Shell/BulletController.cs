using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

namespace TankBattle.Bullet
{
    public class BulletController
    {
        private  BulletView bulletView;
        private  BulletModel bulletModel;
        public readonly TankController sourceTank;

        public BulletController(BulletScriptableObject _bulletScriptableObject, Vector3 _position, Quaternion _rotation, TankController _sourceTank)
        {
            bulletModel = new BulletModel(_bulletScriptableObject);
            bulletView = GameObject.Instantiate<BulletView>(bulletModel.BulletPrefab, _position, _rotation);
            bulletView.SetController(this);
            bulletView.GetComponent<Rigidbody>().AddForce(bulletView.transform.forward * 1000);
            sourceTank = _sourceTank;
        }

        public void DestroyBullet()
        {
            bulletModel = null;
            GameObject.Destroy(bulletView.gameObject);
            bulletView = null;
        }

        public int GetBulletDamagePower()
        {
            return bulletModel.Damage;
        }
    }
}
