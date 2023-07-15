
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

    public PlayerTankView PlayerTank { get; private set; }

    public List<GameObject> PetrolPoints;

    private EnemyTankController enemyTankController;

    public float chaseRadius = 10f;

    public float fightRadius = 5f;
    private void Start()
    {

        EnemyTankModel model = new(TankService.Instance.tankScriptableObjectList.tankScriptableObjects[0]);
        enemyTankController = new(model, this);

        DestoryEverything.Instance.EnemyTanks.Add(this);
        ChangeState(startState);
    }

    public void SetPlayerTank()
    {
        PlayerTank = TankService.Instance.PlayerTank;
    }
    private void Update()
    {
        enemyTankController.ChangeStateBasedOnPlayer();
    }
    public void ChangeState(EnemyTankState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }
    private void OnCollisionEnter(Collision collision)
    {
        BulletView bulletView = collision.gameObject.GetComponent<BulletView>();
        if (bulletView == null)
            return;
        enemyTankController.TakeDamage(bulletView.bulletModel.power);

    }
}
