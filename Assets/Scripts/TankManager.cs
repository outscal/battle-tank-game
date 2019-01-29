using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : Singleton<TankManager> {

    public TankController tankController { get; private set; }

	// Use this for initialization
	void Start () 
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    SpawnTank(false);
        //}

        SpawnTank(true);

    }
	
	private void SpawnTank(bool _isPlayer)
    {
        tankController = new TankController(_isPlayer);
    }
}
