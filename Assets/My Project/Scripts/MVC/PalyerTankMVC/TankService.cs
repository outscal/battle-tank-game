using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class TankService : GenericSingleTon<TankService>
    {
        public TankView tankView;
        [SerializeField] private TankTypeScriptableObjectList tanklist;
        [SerializeField] private ParticleSystem tankExplosion;
        [SerializeField] private CameraController mainCamera;
        private TankController tankController;
        public Vector3 GetPlayerTransform() => tankView.transform.position;
        public Transform GetbulletTransform() => tankController.GetBulletSpwanTransfrom();
        private void Start()
        {
            CreateTank();
        }
        private void CreateTank()
        {
            tankController = new TankController(new TankModel(TankRandomize()), tankView);
        }
        private TankTypeScriptableObject TankRandomize()
        {
            int index = UnityEngine.Random.Range(0, tanklist.list.Count);
            TankTypeScriptableObject tankTypeScriptableObject = tanklist.list[index];
            return tankTypeScriptableObject;
        }
        public void ShootBullet( Transform tankTransform)
        {
            BulletService.Instance.BulletShootByTank(tankTransform);
        }
        public void DestoryTank(TankView tankView)
        {
            Vector3 pos = tankView.transform.position;
           // mainCamera.SetTankTransform(null);
            StartCoroutine(TankExplosion(pos));
            Destroy(tankView.gameObject);
            GameManager.Instance.GameOver();
            //StartCoroutine(LevelService.Instance.DestroyLevel());
        }
        public IEnumerator TankExplosion(Vector3 tankPos)
        {
            ParticleSystem newTankExplosion = GameObject.Instantiate<ParticleSystem>(tankExplosion, tankPos, Quaternion.identity);
            newTankExplosion.Play();
            yield return new WaitForSeconds(2f);
            Destroy(newTankExplosion.gameObject);
        }
    }
}