using Bullet;
using UnityEngine;

namespace Tank
{
    public class TankController : IController
    {
        public TankController(TankModel tankModel, TankView tankPrefab, Transform tankParent)
        {
            C_TankModel = tankModel;
            C_TankParent = tankParent;
            C_TankView = GameObject.Instantiate<TankView>(tankPrefab, 
                                  tankModel.M_SpawnPoint.position, tankModel.M_SpawnPoint.rotation);
            C_TankView.Initialize(this);
        }

        public TankModel C_TankModel { get; private set; }
        public TankView C_TankView { get; private set; }
        public Transform C_TankParent { get; private set; }

        public IModel GetModel()
        {
            return C_TankModel;
        }


        public void FireBullet(Transform bulletTransform)
        {
            BulletController bulletConroller = BulletService.Instance.GetBullet(bulletTransform, C_TankModel.M_TankDamageBooster);
            bulletConroller.FireBullet(bulletTransform, C_TankModel.M_BulletLaunchForce);
        }


        public void TankMove(Rigidbody tankRigidbody, Transform playerTransform, float movementInputValue)
        {

            Vector3 movement = playerTransform.forward * movementInputValue * C_TankModel.M_Speed * Time.deltaTime;
            tankRigidbody.MovePosition(tankRigidbody.position + movement);
        }


        public void TankTurn(Rigidbody tankRigidbody, float turnInputValue)
        {
            float turn = turnInputValue * C_TankModel.M_TurnSpeed * Time.deltaTime;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation);
        }


        public void PlayEngineAudio(float m_MovementInputValue, float m_TurnInputValue, AudioSource m_MovementAudio,
            AudioClip m_EngineDriving, AudioClip m_EngineIdling, float m_OriginalPitch)
        {
            if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
            {
                if (m_MovementAudio.clip == m_EngineDriving)
                {
                    m_MovementAudio.clip = m_EngineIdling;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - C_TankModel.M_PitchRange,
                                                         m_OriginalPitch + C_TankModel.M_PitchRange);
                    m_MovementAudio.Play();
                }
            }
            else
            {
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - C_TankModel.M_PitchRange,
                                                         m_OriginalPitch + C_TankModel.M_PitchRange);
                    m_MovementAudio.Play();
                }
            }
        }

        public void KillTank()
        {
            Object.Destroy(C_TankView.gameObject);
            C_TankModel = null;
            C_TankView = null;
            C_TankParent = null;
        }


        public void OnDeath(ParticleSystem m_ExplosionParticles, Vector3 tankPosition)
        {
            m_ExplosionParticles.transform.position = tankPosition;
            m_ExplosionParticles.gameObject.SetActive(true);

            m_ExplosionParticles.Play();

            TankService.Instance.DestroyTank(this);
        }
    }
}
