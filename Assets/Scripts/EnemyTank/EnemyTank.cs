using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoSingleton<EnemyTank> {

    protected override void Awake() {
        base.Awake();

        // new code...
    }

    public void Move() {
        // Movement code...
    }

    public void Shoot() {
        // Shooting code...
    }

    public void Block() {
        // Blocking code...
    }
}
