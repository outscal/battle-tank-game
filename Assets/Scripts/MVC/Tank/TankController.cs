using UnityEngine;

public class TankController
{
    TankModel m_tankModel;
    TankView m_tankView;


    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public TankController(TankModel tankModel, TankView tankView)
    {
        //receive the tankmodel
        m_tankModel = tankModel;

        //instantiate the game object
        m_tankView = GameObject.Instantiate<TankView>(tankView);
        m_tankModel.SetTankController(this);
        m_tankView.SetTankController(this);

        Debug.Log("TankView created");
    }

    public void Move(Vector2 movementInput, float playerSpeed, bool groundedPlayer, Vector3 playerVelocity, CharacterController controller, GameObject gameObject)
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }

    public TankModel GetTankModel(){
        return m_tankModel;
    }


}