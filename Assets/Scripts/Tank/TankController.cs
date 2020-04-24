using Bullet;
using Singalton;
using System.Collections;
using UnityEngine;

namespace Tank
{
    public class TankController : IController
    {
        public TankController(TankModel tankModel, TankView tankPrefab, Transform tankParent)
        {
            TankModel = tankModel;
            TankParent = tankParent;
            TankView = GameObject.Instantiate<TankView>(tankPrefab, 
                                  tankModel.SpawnPoint.position, tankModel.SpawnPoint.rotation);
            TankView.Initialize(this);
        }

        public TankModel TankModel { get; private set; }
        public TankView TankView { get; private set; }
        public Transform TankParent { get; private set; }

        public IModel GetModel()
        {
            return TankModel;
        }


        public void FireBullet(Transform bulletTransform)
        {
            BulletController bulletConroller = BulletService.Instance.GetBullet(bulletTransform, TankModel.TankDamageBooster);
            bulletConroller.FireBullet(bulletTransform, TankModel.BulletLaunchForce);
        }


        public void TankMove(Rigidbody tankRigidbody, Transform playerTransform, float movementInputValue)
        {

            Vector3 movement = playerTransform.forward * movementInputValue * TankModel.Speed * Time.deltaTime;
            tankRigidbody.MovePosition(tankRigidbody.position + movement);
        }


        public void TankTurn(Rigidbody tankRigidbody, float turnInputValue)
        {
            float turn = turnInputValue * TankModel.TurnSpeed * Time.deltaTime;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation);
        }


        public void PlayEngineAudio(float movementInputValue, float turnInputValue, AudioSource movementAudio,
            AudioClip engineDriving, AudioClip engineIdling, float originalPitch)
        {
            if (Mathf.Abs(movementInputValue) < 0.1f && Mathf.Abs(turnInputValue) < 0.1f)
            {
                if (movementAudio.clip == engineDriving)
                {
                    movementAudio.clip = engineIdling;
                    movementAudio.pitch = Random.Range(originalPitch - TankModel.PitchRange,
                                                         originalPitch + TankModel.PitchRange);
                    movementAudio.Play();
                }
            }
            else
            {
                if (movementAudio.clip == engineIdling)
                {
                    movementAudio.clip = engineDriving;
                    movementAudio.pitch = Random.Range(originalPitch - TankModel.PitchRange,
                                                         originalPitch + TankModel.PitchRange);
                    movementAudio.Play();
                }
            }
        }

        public void KillTank()
        {
            Object.Destroy(TankView.gameObject);
            TankModel = null;
            TankView = null;
            TankParent = null;
        }


        public void OnDeath(Vector3 tankPosition)
        {
            //explosionParticles.transform.position = tankPosition;
            //explosionParticles.gameObject.SetActive(true);

            //explosionParticles.Play();
            VFXManager.Instance.PlayVFXClip(VFXName.TankExplosion, tankPosition, TankParent);
            SoundManager.Instance.PlaySoundClip(ClipName.TankExplosion);
            TankService.Instance.DestroyTank(this);
        }


    }
}
