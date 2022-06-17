using UnityEngine;


public class EnemyTankController
{
    public EnemyTankView _enemyTankView;
    public EnemyTankModel _enemyTankModel;
    public float _movementSpeed;
    public float _rotationSpeed;
    public EnemyTankModel EnemyTankModel { get; }
    public EnemyTankView EnemyTankView { get; }

    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
    {
        _enemyTankModel = enemyTankModel;

        _movementSpeed = enemyTankModel.MovementSpeed;
        _rotationSpeed = enemyTankModel.RotationSpeed;

        _enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView);

        _enemyTankModel.SetController(this);
        _enemyTankView.SetController(this);
        SetEnemyTankColor(enemyTankView, enemyTankModel);

        Debug.Log("EnemyTankView created");
    }

    public void SetEnemyTankColor(EnemyTankView enemyTankview, EnemyTankModel enemyTankModel)
    {
        //Get the Renderer component from the new cube
        var renderer = enemyTankview.GetComponentInChildren<MeshRenderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        renderer.sharedMaterial.SetColor("_Color", enemyTankModel.EnemyTankColor);
    }


}
