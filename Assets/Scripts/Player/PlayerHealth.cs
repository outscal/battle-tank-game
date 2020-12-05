using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : TankHealth{

    [SerializeField]private GameObject gameOverUI;

    protected override void PlayerDead(){
        base.PlayerDead();
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }

        gameOverUI.SetActive(true);
    }

}
