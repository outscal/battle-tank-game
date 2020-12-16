using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem dust;
    [SerializeField]
    Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        if (joystick.pressed)
        {
            dust.Play();
        }
        else {
            dust.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
