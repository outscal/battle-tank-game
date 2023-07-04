

using UnityEngine;

public class TankController 
{
    private Rigidbody rb;
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel _tankModel,TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = Object.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidbody();

        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }

    
    public TankModel GetTankModel()
    {
        return tankModel;
    }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
