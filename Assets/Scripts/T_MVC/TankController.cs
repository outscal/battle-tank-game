using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerTankService
{
    public class TankController
    {
        public Joystick tankMovementJoystick;
        [SerializeField]
        public TankModel TankModel { get; set; }
        public TankView TankView { get; set; }
        public object AudioManager { get; private set; }

        public Camera camera;
        private Rigidbody tankRigidbidy;
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            this.TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            tankRigidbidy = TankView.GetComponent<Rigidbody>();
            TankView.SetTankController(this);
            TankModel.SetTankController(this);
        }
        public void setHealthUI()
        {
            TankView.healthSlider.maxValue = TankModel.MaxHealth;
            TankView.healthSlider.value = TankModel.Health;
            TankView.fillImage.color = Color.Lerp(TankModel.ZeroHealthColor, TankModel.FullHealthColor, TankModel.Health / TankModel.MaxHealth);
        }
        public void increaseHealth()
        {
            if (TankModel.Health <= TankModel.MaxHealth)
            {
                TankModel.Health += Random.Range(10, 26);
                setHealthUI();
            }
        }
        public void applyDamage(float damage)
        {
            TankModel.Health -= damage;
            setHealthUI();
            if(TankModel.Health <= 0)
            {
                TankView.instantiateTankExplosionParticles();
                /*                AudioManager.Instance.explosionAudio.GetComponent<AudioSource>().Play();*/
                destroyController();
            }
        }

        public void EngineAudio()
        {
            //Playing audio when tank is moving vs not moving 
/*            if (Mathf.Abs(TankView.Mo) < 0.1f && Mathf.Abs(TankView.TurnInputValue) < 0.1f)
            {*/
                if (TankView.MovementAudio.clip == TankView.EngineDriving)
                {
                    TankView.MovementAudio.clip = TankView.EngineIdling;
                    TankView.MovementAudio.pitch = Random.Range(TankView.OriginalPitch - TankView.PitchRange, TankView.OriginalPitch + TankView.PitchRange);
                    TankView.MovementAudio.Play();
                }
/*            }*/
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
        public void setJoysticks(Joystick movemenetJoystick)
        {
            tankMovementJoystick = movemenetJoystick;         
        }
        public void setCameraReference(Camera _cam)
        {
            camera = _cam;
            camera.transform.SetParent(TankView.transform);
        }
        public void Move()
        {
            //Adjusting position of tank
            Vector3 move = tankMovementJoystick.Vertical * tankRigidbidy.transform.forward * TankModel.Speed* Time.deltaTime;
            tankRigidbidy.MovePosition(tankRigidbidy.transform.position + move);
        }
        public void Turn()
        {
            //Adjusting rotation of tank
            float turn = tankMovementJoystick.Horizontal * TankModel.TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            TankView.Rigidbody.MoveRotation(TankView.Rigidbody.rotation * turnRotation);
        }
        public void destroyController()
        {
            camera.transform.parent = null;
            TankModel.destroyModel();
            TankView.destroyView();
            TankModel = null;
            TankView = null;
            /*GameManager.Instance.DestroyAllObjects();*/
        }
    }
}

