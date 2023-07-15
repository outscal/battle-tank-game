
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankIdleState idleState;
    public EnemyTankChaseState chaseState;
    public EnemyTankFightState fightState;
    public EnemyTankPetrolState petrolState;

    public EnemyTankState startState;
    public EnemyTankState currentState;

    public List<GameObject> PetrolPoints;

    private EnemyTankController enemyTankController;
    private void Start()
    {
        DestoryEverything.Instance.EnemyTanks.Add(this);
        enemyTankController.ChangeState(startState);
    }
    public void SetEnemyTankController(EnemyTankController tankController)
    {
        enemyTankController = tankController;
    }
    private void OnCollisionEnter(Collision collision)
    {
        BulletView bulletView = collision.gameObject.GetComponent<BulletView>();
        if (bulletView == null)
            return;
        enemyTankController.TakeDamage(bulletView.bulletModel.power);

    }
}
