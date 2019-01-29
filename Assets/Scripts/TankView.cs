using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour {

    [SerializeField]
    private GameObject bulletSpawnPos;

    public GameObject BulletSpawnPos
    {
        get { return bulletSpawnPos; }
    }

    public void MoveTank(float hVal, float vVal, float speed, float rotateSpeed)
    {
        transform.Translate(vVal * Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, hVal, 0) * rotateSpeed);
    }

}

	