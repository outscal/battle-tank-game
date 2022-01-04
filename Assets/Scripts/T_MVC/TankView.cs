using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public AudioSource MovementAudio;
    public AudioClip EngineIdling;
    public AudioClip EngineDriving;
    public float PitchRange = 0.2f;
    public string MovementAxisName;
    public string TurnAxisName;
    public float MovementInputValue;
    public float TurnInputValue;
    public float OriginalPitch;

    private void Start()
    {
        
    }
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
}
