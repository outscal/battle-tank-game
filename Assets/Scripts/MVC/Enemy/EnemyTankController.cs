using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel m_enemyTankModel;
    private EnemyTankView m_enemyTankView;

    public EnemyTankModel EnemyTankModel { get; }
    public EnemyTankView EnemyTankView { get; }

    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
    {
        //receive the enemymodel
        m_enemyTankModel = enemyTankModel;

        //instantiate the enemy game object
        m_enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView);

        m_enemyTankModel.SetEnemyTankController(this);
        m_enemyTankView.SetEnemyTankController(this);
    }

    public void Move(Vector2 movementInput, float playerSpeed, bool groundedPlayer, Vector3 enemyVelocity, CharacterController controller,GameObject gameObject)
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && enemyVelocity.y < 0)
        {
            enemyVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }

    public EnemyTankModel GetEnemyTankModel()
    {
        return m_enemyTankModel;
    }
}
