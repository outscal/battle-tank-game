using UnityEngine;

public class PlayerTankController
{
    private PlayerTankModel model;
    private PlayerTankView view;
    private PlayerTankModel playerTankModel;
    private BulletScriptableObject bulletScriptableObject;


    public PlayerTankController(PlayerTankModel playerTankModel)
    {
        this.playerTankModel = playerTankModel;
    }

    public PlayerTankController(PlayerTankModel _model, PlayerTankView _view)
    {
        model = _model;
        view = _view;
    }

    public void Update()
    {
        // handle user input and update the model and view accordingly
        if (Input.GetKey(KeyCode.UpArrow))
        {
            model.Move(1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            model.Move(-1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            model.Rotate(-1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            model.Rotate(1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            model.Shoot(bulletScriptableObject);
            Debug.Log("Bullet Fired");
        }
    }

}
