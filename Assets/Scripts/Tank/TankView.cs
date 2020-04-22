using UnityEngine;
using Generic;

namespace Tank
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody), typeof(TankHealth))]
    public class TankView : MonoBehaviour, Destructable
    {
        public Transform m_FireTransform;
        public AudioSource m_MovementAudio;
        public AudioClip m_EngineIdling;
        public AudioClip m_EngineDriving;
        public ParticleSystem[] m_particleSystems;

        private string m_MovementAxisName;
        private string m_TurnAxisName;
        private Rigidbody m_Rigidbody;
        private float m_MovementInputValue;
        private float m_TurnInputValue;
        private float m_OriginalPitch;
        private float m_PitchRange;
        private float m_TurnSpeed;
        private float m_Speed;
        private int m_PlayerNumber;
        private KeyCode m_FireButton;
        private TankController tankController;


        public void Initialize(TankController tankController)
        {
            this.tankController = tankController;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            transform.SetParent(tankController.C_TankParent);
            m_PlayerNumber = tankController.GetModel().M_PlayerNumber;
            m_Rigidbody = GetComponent<Rigidbody>();
            m_FireButton = tankController.GetModel().FireKey;
            GetComponent<TankHealth>().Initialize(tankController);
            //Debug.Log("Health " + tankController.GetModel().Health, this);
            m_Rigidbody.isKinematic = false;

            m_MovementInputValue = 0f;
            m_TurnInputValue = 0f;

            
            for (int i = 0; i < m_particleSystems.Length; ++i)
            {
                m_particleSystems[i].Play();
            }
        }



        private void OnDisable()
        {
            m_Rigidbody.isKinematic = true;

            for (int i = 0; i < m_particleSystems.Length; ++i)
            {
                m_particleSystems[i].Stop();
            }
        }


        private void Start()
        {
            m_MovementAxisName = Constants.VerticalInput + m_PlayerNumber;
            m_TurnAxisName = Constants.HorizontalInput + m_PlayerNumber;

            m_OriginalPitch = m_MovementAudio.pitch;
        }


        private void Update()
        {
            ChekingPlayerInput();

            tankController.PlayEngineAudio(m_MovementInputValue, m_TurnInputValue, m_MovementAudio,
                                       m_EngineDriving, m_EngineIdling, m_OriginalPitch);
        }


        private void ChekingPlayerInput()
        {
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
            m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

            if (Input.GetKeyDown(m_FireButton))
            {
                tankController.FireBullet(m_FireTransform);
            }
        }


        private void FixedUpdate()
        {
            tankController.TankMove(m_Rigidbody, transform, m_MovementInputValue);

            tankController.TankTurn(m_Rigidbody, m_TurnInputValue);
        }

    }
}
