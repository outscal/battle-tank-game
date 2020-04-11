using UnityEngine;


namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class TankView : MonoBehaviour
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
            m_PlayerNumber = tankController.GetModel().M_PlayerNumber;
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Speed = tankController.GetModel().Speed;
            m_TurnSpeed = tankController.GetModel().M_TurnSpeed;
            m_PitchRange = tankController.GetModel().M_PitchRange;
            m_particleSystems = GetComponentsInChildren<ParticleSystem>();
            m_FireButton = tankController.GetModel().FireKey;

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

            EngineAudio();
        }


        private void ChekingPlayerInput()
        {
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
            m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

            if (Input.GetKeyDown(m_FireButton))
            {
                tankController.Fire(m_FireTransform, 0);
            }
        }


        private void EngineAudio()
        {
            if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
            {
                if (m_MovementAudio.clip == m_EngineDriving)
                {
                    m_MovementAudio.clip = m_EngineIdling;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play();
                }
            }
            else
            {
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play();
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

            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;


            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }


        private void Turn()
        {
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        }
    }
}
