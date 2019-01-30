using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager> {

    public PlayerController tankController { get; private set; }

	// Use this for initialization
	void Start () 
    {
        SpawnTank();

    }
	
	private void SpawnTank()
    {
        tankController = new PlayerController();
    }
}
