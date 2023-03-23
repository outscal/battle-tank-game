using UnityEngine;

public class TankService : GenericSingleton<TankService> {

    [SerializeField] private TankView tankView;
    private TankController tankController;

    private float movementSpeed = 10;
    private float rotationSpeed = 50;
    
    private void Start()
    {
        new TankController(new TankModel(movementSpeed, rotationSpeed), tankView);   // Creating Tank
    }
}
