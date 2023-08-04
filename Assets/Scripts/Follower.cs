using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]private  GameObject toFollow;

    public void AddFollower(TankView tankView)
    {
        toFollow = tankView.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (toFollow != null)
        {
            transform.position = toFollow.transform.position;
        }
    }
}
