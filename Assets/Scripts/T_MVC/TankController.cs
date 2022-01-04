using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerTankService
{
    public class TankController
    {
        [SerializeField]
        private Joystick joystick;
        public TankModel TankModel { get; }
        public TankView TankView { get; }
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
        }
        [SerializeField]
        private float Speed = 10f;
        [SerializeField]
        private float TurnSpeed = 180f;
        private void OnEnable()
        {
            TankView.Rigidbody.isKinematic = false;    // No forces applied
            TankView.MovementInputValue = 0;
            TankView.TurnInputValue = 0;
        }
        private void OnDisable()
        {
            TankView.Rigidbody.isKinematic = true;
        }
        private void Start()
        {
            TankView.MovementAxisName = "Vertical";
            TankView.TurnAxisName = "Horizontal";
            TankView.OriginalPitch = TankView.MovementAudio.pitch;
        }
        private void Update()
        {
            TankView.MovementInputValue = joystick.Vertical;
            TankView.TurnInputValue = joystick.Horizontal;
            EngineAudio();
        }
        private void EngineAudio()
        {
            //Playing audio when tank is moving vs not moving 
            if (Mathf.Abs(TankView.MovementInputValue) < 0.1f && Mathf.Abs(TankView.TurnInputValue) < 0.1f)
            {
                if (TankView.MovementAudio.clip == TankView.EngineDriving)
                {
                    TankView.MovementAudio.clip = TankView.EngineIdling;
                    TankView.MovementAudio.pitch = Random.Range(TankView.OriginalPitch - TankView.PitchRange, TankView.OriginalPitch + TankView.PitchRange);
                    TankView.MovementAudio.Play();
                }
            }
            else
            {
                if (TankView.MovementAudio.clip == TankView.EngineIdling)
                {
                    TankView.MovementAudio.clip = TankView.EngineDriving;
                    TankView.MovementAudio.pitch = Random.Range(TankView.OriginalPitch - TankView.PitchRange, TankView.OriginalPitch + TankView.PitchRange);
                    TankView.MovementAudio.Play();
                }
            }
        }
        private void FixedUpdate()
        {
            Move();
            Turn();
        }
        private void Move()
        {
            //Adjusting position of tank
            Vector3 movement = TankView.transform.forward * TankView.MovementInputValue * Speed * Time.deltaTime;  //Speed per frame
            TankView.Rigidbody.MovePosition(TankView.Rigidbody.position + movement);
        }
        private void Turn()
        {
            //Adjusting rotation of tank
            float turn = TankView.TurnInputValue * TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            TankView.Rigidbody.MoveRotation(TankView.Rigidbody.rotation * turnRotation);
        }
    }
}

