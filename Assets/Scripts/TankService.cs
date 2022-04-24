using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{

    public TankView tankView;
    // Start is called before the first frame update
    void Start()
    {
        TankModel model = new TankModel(5, 100f);
        TankControllerScript tankController = new TankControllerScript(model, tankView);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
