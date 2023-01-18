using UnityEngine;

public class PlayerTankController
{
    private PlayerTankModel model;
    private PlayerTankView view;


    public PlayerTankController(PlayerTankModel model, PlayerTankView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Update()
    {
        model.UpdatePlayerPosition(view.transform.position);
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
            model.Shoot();
        }
    }
}



