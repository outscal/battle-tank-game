using Bullet;
using UnityEngine;

namespace Tank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab, Transform tankParent)
        {
            TankModel = tankModel;
            TankParent = tankParent;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            TankView.Initialize(this);
        }

        public TankModel TankModel { get; }
        public Transform TankParent { get; }
        public TankView TankView { get; }


        public TankModel GetModel()
        {
            return TankModel;
        }


        public void FireBullet(Transform bulletTransform, float bulletDamange)
        {
            BulletConroller bulletConroller = BulletService.Instance.GetBullet(bulletTransform, bulletDamange);
            bulletConroller.BulletView.bulletBody.velocity = bulletConroller.BulletView.m_LaunchForce * bulletTransform.forward;
        }


        public void TankMove(Rigidbody tankRigidbody, Transform playerTransform, float movementInputValue)
        {

            Vector3 movement = playerTransform.forward * movementInputValue * TankModel.Speed * Time.deltaTime;
            tankRigidbody.MovePosition(tankRigidbody.position + movement);
        }


        public void TankTurn(Rigidbody tankRigidbody, float turnInputValue)
        {
            float turn = turnInputValue * TankModel.M_TurnSpeed * Time.deltaTime;

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
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - TankModel.M_PitchRange,
                                                         m_OriginalPitch + TankModel.M_PitchRange);
                    m_MovementAudio.Play();
                }
            }
            else
            {
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - TankModel.M_PitchRange,
                                                         m_OriginalPitch + TankModel.M_PitchRange);
                    m_MovementAudio.Play();
                }
            }
        }

    }
}
