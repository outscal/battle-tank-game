
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    //tankscriptableobjectscript temp; for debug purposes only

    public TankModel(TankScriptableObjectScript tankScriptObject, int spawnIndex)
    {
        //this.temp = tankScriptObject; //for debug puposes only
        Health = tankScriptObject.tankHealth;
        Damage = tankScriptObject.damageOutput;
        MovSpeed = tankScriptObject.tankSpeed;
        SpawnIndex = spawnIndex;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public int Health
    {
        get;
    }
    public int Damage
    {
        get;
    }
    public float MovSpeed
    {
        get;
    }

    public int SpawnIndex
    {
        get;
    }
}
