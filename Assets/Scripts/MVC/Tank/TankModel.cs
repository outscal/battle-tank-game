using UnityEngine;
public class TankModel
{
    //tank properties
    public TankTypes TankType;
    public string TankName;
    public float MovementSpeed { get; }
    public float RotationSpeed { get; }
    public float Health { get; }
    public Color TankColor { get; }
    public Joystick Joystick { get; }

    TankController _tankController;

    //constructor
    public TankModel(TankSO tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        TankName = tankScriptableObject.TankName;
        MovementSpeed = tankScriptableObject.MovementSpeed;
        RotationSpeed = tankScriptableObject.RotationSpeed;
        Health = tankScriptableObject.Health;
        TankColor = tankScriptableObject.TankColor;
    }


    public void SetController(TankController tankController)
    {
        _tankController = tankController;
    }

}