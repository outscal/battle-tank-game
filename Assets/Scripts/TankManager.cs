using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : Singleton<TankManager> {

    public TankController tankController { get; private set; }

	// Use this for initialization
	void Start () 
    {
        SpawnTank();

    }
	
	private void SpawnTank()
    {
        tankController = new TankController();
    }
}
