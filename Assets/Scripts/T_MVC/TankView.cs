using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerTankService
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankView : MonoBehaviour
    {
        public Rigidbody Rigidbody;
        private Joystick joystick;
        public AudioSource MovementAudio;
        public AudioClip EngineIdling;
        public AudioClip EngineDriving;
        public float PitchRange = 0.2f;
        public string MovementAxisName;
        public string TurnAxisName;
        public float OriginalPitch;   //To stable the audio pitch
        private TankController tankcontroller;

         private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
        private void OnEnable()
        {
            Rigidbody.isKinematic = false;    // No forces applied
        }
        private void OnDisable()
        {
           Rigidbody.isKinematic = true;
        }
        private void Start()
        {
            MovementAxisName = "Vertical";
            TurnAxisName = "Horizontal";
            OriginalPitch = MovementAudio.pitch;
            setTankColor();
        }
        private void Update()
        {
/*            MovementInputValue = joystick.Vertical;
            TurnInputValue = joystick.Horizontal;*/
            tankcontroller.EngineAudio();
        }
        private void FixedUpdate()
        {
           tankcontroller.Move();  //For all phyics maths
           tankcontroller.Turn();
        }
        public void SetTankController(TankController controller)
        {
            tankcontroller = controller;
        }
        public void setJoysticks(Joystick movementJoystick, Joystick turretJoystick)
        {
            tankcontroller.tankMovementJoystick = movementJoystick;
/*            turretRotateJoystick = turretJoystick;*/
        }
        public void setTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = tankcontroller.TankModel.tankColor;
            }
        }
    }

}
