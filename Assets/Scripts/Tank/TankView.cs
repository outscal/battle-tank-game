using UnityEngine;


namespace Tank
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody), typeof(TankHealth))]
    public class TankView : MonoBehaviour
    {
        public Transform FireTransform;
        public AudioSource MovementAudio;
        public AudioClip EngineIdling;
        public AudioClip EngineDriving;
        public ParticleSystem[] ParticleSystems;

        private string movementAxisName;
        private string turnAxisName;
        private Rigidbody tankBody;
        private float movementInputValue;
        private float turnInputValue;
        private float originalPitch;
        private float pitchRange;
        private float turnSpeed;
        private float speed;
        private int playerNumber;
        private KeyCode fireButton;
        private TankController tankController;


        public void Initialize(TankController tankController)
        {
            this.tankController = tankController;
            InitAllVariables();
        }


        private void InitAllVariables()
        {
            transform.SetParent(tankController.TankParent);
            playerNumber = tankController.GetModel().PlayerNumber;
            tankBody = GetComponent<Rigidbody>();
            fireButton = tankController.GetModel().FireKey;
            GetComponent<TankHealth>().Initialize(tankController);

            tankBody.isKinematic = false;

            movementInputValue = 0f;
            turnInputValue = 0f;

            
            for (int i = 0; i < ParticleSystems.Length; ++i)
            {
                ParticleSystems[i].Play();
            }
        }



        private void OnDisable()
        {
            tankBody.isKinematic = true;

            for (int i = 0; i < ParticleSystems.Length; ++i)
            {
                ParticleSystems[i].Stop();
            }
        }


        private void Start()
        {
            movementAxisName = Constants.VerticalInput + playerNumber;
            turnAxisName = Constants.HorizontalInput + playerNumber;

            originalPitch = MovementAudio.pitch;
        }


        private void Update()
        {
            ChekingPlayerInput();

            tankController.PlayEngineAudio(movementInputValue, turnInputValue, MovementAudio,
                                       EngineDriving, EngineIdling, originalPitch);
        }


        private void ChekingPlayerInput()
        {
            movementInputValue = Input.GetAxis(movementAxisName);
            turnInputValue = Input.GetAxis(turnAxisName);

            if (Input.GetKeyDown(fireButton))
            {
                tankController.FireBullet(FireTransform);
            }
        }


        private void FixedUpdate()
        {
            tankController.TankMove(tankBody, transform, movementInputValue);

            tankController.TankTurn(tankBody, turnInputValue);
        }

        public void KillView()
        {
            Destroy(gameObject);
        }
    }
}
