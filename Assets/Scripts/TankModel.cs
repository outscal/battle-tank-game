using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public float movement_speed;
    public float rotation_speed;
    private TankController tankController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public TankModel(float _movement, float _rotation)
    {
        movement_speed = _movement;
        rotation_speed = _rotation;
    }

    public void SetTankController (TankController _tankController)
    {
        tankController = _tankController;
    }

    
}
