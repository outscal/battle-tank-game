using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;

    //contructor for setting up the references
    public TankController(TankModel _tankModel, TankView _tankview) 
    {   
        //filling the reference of tankmodel and tankView
        tankModel = _tankModel;
        tankView = _tankview;

        //passing the reference to the function of this tankcontroller where this script is attached 
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        //instantiating tankView gameobject
        GameObject.Instantiate(tankView.gameObject);
    }
}
