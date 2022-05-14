using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    EnemyTankController m_enemyTankController;
    Vector2 m_enemyTankMovement;
    private CharacterController m_enemyCharacterController;
    private Player enemyInput;
    private Vector3 enemyVelocity;
    private bool groundedPlayer;

    [SerializeField]
    private float enemySpeed = 10.0f;
    private void Awake()
    {
        //assigning an object of the input action to the input action reference
        enemyInput = new Player();
        //getting the reference for character controller
        m_enemyCharacterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        enemyInput.Enable();
    }

    private void OnDisable()
    {
        enemyInput.Disable();
    }


    //-----controller reference-----
    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        m_enemyTankController = enemyTankController;
    }

    public void Update()
    {
        Vector2 movementInput = enemyInput.PlayerMain.Movement.ReadValue<Vector2>();
        m_enemyTankController.Move(movementInput, m_enemyTankController.GetEnemyTankModel().Speed, groundedPlayer, enemyVelocity, m_enemyCharacterController, gameObject);
    }


}

