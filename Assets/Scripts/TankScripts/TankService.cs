using System.Collections;
using UnityEngine;
using BattleTank.Generics;
using BattleTank.ScriptableObjects;
using BattleTank.Events;
using BattleTank.Level;
using BattleTank.PlayerCamera;
using BattleTank.Bullet;

public enum TankType
{
    Player, Enemy
}

namespace BattleTank.PlayerTank
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankController tankController;

        [SerializeField] private TankScriptableObjectList playerTankList;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private CameraController mainCamera;
        [SerializeField] private ParticleSystem tankExplosion;

        private void Start()
        {
            CreatePlayerTank(UnityEngine.Random.Range(0, playerTankList.tanks.Length));
        }

        public void CreatePlayerTank(int index)
        {
            TankScriptableObject tank = playerTankList.tanks[index];
            tankController = new TankController(tank, joystick, mainCamera);
        }

        public void ShootBullet(BulletType bulletType, Transform tankTransform)
        {
            EventService.Instance.InvokePlayerFiredBullet();
            BulletService.Instance.SpawnBullet(bulletType, tankTransform, TankType.Player);
        }

        public void DestoryTank(TankView tankView)
        {
            Vector3 pos = tankView.transform.position;

            mainCamera.SetTankTransform(null);
            Destroy(tankView.gameObject);

            StartCoroutine(TankExplosion(pos));
            StartCoroutine(LevelService.Instance.DestroyLevel());
        }

        public IEnumerator TankExplosion(Vector3 tankPos)
        {
            ParticleSystem newTankExplosion = GameObject.Instantiate<ParticleSystem>(tankExplosion, tankPos, Quaternion.identity);

            newTankExplosion.Play();
            yield return new WaitForSeconds(2f);

            Destroy(newTankExplosion.gameObject);
            yield return new WaitForSeconds(2f);
        }

        public Transform GetPlayerTransform()
        {
            return tankController.GetTransform();
        }

        public void distanceTravelled(float distance)
        {
            EventService.Instance.InvokeDistanceTravelled(distance);
        }
    }
}
