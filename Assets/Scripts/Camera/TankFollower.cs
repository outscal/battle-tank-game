using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFollower : MonoBehaviour {

    [SerializeField] Transform tank;

    Vector3 initPos;
    Vector3 tankInitPos;

    private void Awake() {
        initPos = transform.position;
        tankInitPos = tank.position;
    }

    private void Update() {
        transform.position = initPos + (tank.position - tankInitPos);
    }

}
