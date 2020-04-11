using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletServices
{
    public class BulletController
    {
        public BulletView bulletView { get; }
        public BulletModel bulletModel { get; }
        public BulletService bulletService { get; }

        public BulletController(BulletView _bulletView, BulletModel _bulletModel, BulletService _bulletService)
        {
            bulletModel = _bulletModel;
            bulletService = _bulletService;
            bulletView = GameObject.Instantiate<BulletView>(_bulletView);
            bulletView.transform.parent = this.bulletService.transform;


            bulletView.GetBulletController(this);
            bulletModel.GetBulletController(this);
        }

    }
}