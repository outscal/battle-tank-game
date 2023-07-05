using System;
using System.Collections;
using UnityEngine;
using BattleTank.PlayerCamera;
public enum TankType
{
    Player, Enemy
}
public class TankService : GenericSingleton<TankService>
{
    public event Action OnPlayerFiredBullet;
    public event Action<float> OnDistanceTravelled;
    [SerializeField] TankScriptableObjectList playerTankList;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] CameraController mainCamera;
    [SerializeField] ParticleSystem tankExplosion;
    TankController tankController;
    TankType tankType = TankType.Player;
    void Start()
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
        OnPlayerFiredBullet?.Invoke();
        BulletService.Instance.SpawnBullet(bulletType, tankTransform, tankType);
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
        OnDistanceTravelled?.Invoke(distance);
    }
}
