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
        public Slider healthSlider;
        public Image fillImage;
        public string MovementAxisName;
        public string TurnAxisName;
        public float OriginalPitch;   //To stable the audio pitch
        private TankController tankcontroller;
        [SerializeField]
        private ParticleSystem explosionParticles;

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
            OriginalPitch = MovementAudio.pitch;
            setTankColor();
            tankcontroller.setHealthUI();
        }
        private void Update()
        {
/*            tankcontroller.EngineAudio();*/
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
        public void instantiateTankExplosionParticles()
        {
            ParticleSystem tankExplosion = Instantiate(explosionParticles, transform.position, transform.rotation);
            tankExplosion.Play();
            Destroy(tankExplosion, 1f);
        }
        public void destroyView()
        {
            tankcontroller = null;
            explosionParticles = null;
            Destroy(this.gameObject);
/*            bulletShootPoint = null;
            healeffect = null;*/
        }
    }
}
