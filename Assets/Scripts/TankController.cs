using System;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }

    public TankController(TankModel model, TankView view)
    {
        tankModel = model;
        tankView = view;
    }

    public void OnPositionChanged(Vector3New position)
    {

    }
	
}
