
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

    private float chaseRadius = 10f;

    private float fightRadius = 5f;
    private void Start()
    {

        EnemyTankModel model = new(TankService.Instance.tankScriptableObjectList.tankScriptableObjects[0]);
        enemyTankController = new(model, this);

        DestoryEverything.Instance.EnemyTanks.Add(this);
        PlayerTank = TankService.Instance.PlayerTank;
        ChangeState(startState);
    }
    private void Update()
    {
        if (PlayerTank == null)
        {
            Debug.Log("No Player Tank");
            PlayerTank = TankService.Instance.PlayerTank;
            return;

        }
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerTank.transform.position);
        if (distanceToPlayer > fightRadius && distanceToPlayer <= chaseRadius)
            ChangeState(chaseState);
        else if (distanceToPlayer <= fightRadius)
            ChangeState(fightState);
        else if (currentState != petrolState)
            ChangeState(petrolState);
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
