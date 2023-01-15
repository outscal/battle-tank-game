using UnityEngine;

public class EnemyController
{
    private EnemyModel model;
    private EnemyView view;
    private Transform playerTank;

    public EnemyController(EnemyModel _model, EnemyView _view, Transform _playerTank)
    {
        model = _model;
        view = _view;
        playerTank = _playerTank;
    }

    public void Update()
    {
        // Update the position of the enemy based on its speed
        view.transform.position += view.transform.forward * model.Speed * Time.deltaTime;

        // rotate the enemy towards the player tank
        view.transform.LookAt(playerTank);
    }

    public void TakeDamage(float damage)
    {
        model.Health -= damage;

        // Update the color of the enemy based on its health
        if (model.Health > 0)
        {
            view.UpdateColor(Color.green);
        }
        else
        {
            view.UpdateColor(Color.red);
        }
    }
}
