
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

        EnemyTankModel model = new(TankService.Instance.tankScriptableObjectList.tankScriptableObjects[0]);
        enemyTankController = new(model, this);

        DestoryEverything.Instance.EnemyTanks.Add(this);
        enemyTankController.ChangeState(startState);
    }
    private void OnCollisionEnter(Collision collision)
    {
        BulletView bulletView = collision.gameObject.GetComponent<BulletView>();
        if (bulletView == null)
            return;
        enemyTankController.TakeDamage(bulletView.bulletModel.power);

    }
}
