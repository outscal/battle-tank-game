using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager> {

    public PlayerController playerController { get; private set; }

	// Use this for initialization
	void Start () 
    {
        SpawnTank();

    }
	
	private void SpawnTank()
    {
        playerController = new PlayerController();
        InputManager.Instance.playerController = playerController;
    }
}
