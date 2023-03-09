using TankBattle.Tank.Bullets;
using UnityEngine;
using UnityEngine.UI;

namespace TankBattle.Tank.PlayerTank
{
    public class TankShooting : MonoBehaviour
    {
        [SerializeField] private Transform fireTransform;
        [SerializeField] private Slider aimSlider;
        [SerializeField] private AudioSource shootingAudio;
        [SerializeField] private AudioClip chargingClip;
        [SerializeField] private AudioClip fireClip;
        [SerializeField] private float minLaunchForce = 15f;
        [SerializeField] private float maxLaunchForce = 30f;
        [SerializeField] private float maxChargeTime = 0.75f;

        private readonly string fireButton = "Fire1";
        private float currentLaunchForce;
        private float chargeSpeed;
        private bool isFired;

        private void OnEnable()
        {
            currentLaunchForce = minLaunchForce;
            aimSlider.value = minLaunchForce;
        }
        private void Start()
        {
            chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
        }
        private void Update()
        {
            // track input press
            aimSlider.value = minLaunchForce;

            if (currentLaunchForce >= maxLaunchForce && !isFired)
            {
                // at max charge, not fired yet
                currentLaunchForce = maxLaunchForce;
                Fire();
            }
            else if(Input.GetButtonDown(fireButton))
            {
                // when fire button is pressed for first time
                isFired = false;
                currentLaunchForce = minLaunchForce;
                //play charging sound
                shootingAudio.clip = chargingClip;
                shootingAudio.Play();
            }
            else if(Input.GetButton(fireButton) && !isFired)
            {
                // holding fire button, not fired yet
                currentLaunchForce += chargeSpeed * Time.deltaTime;
                aimSlider.value = currentLaunchForce;
            }
            else if(Input.GetButtonUp(fireButton) && !isFired)
            {
                // button released, change isFired here
                Fire();
            }
        }

        // fire function goes should go inside player / tank controller
        private void Fire()
        {
            // instantiate and launch bullet/shell
            isFired = true;

            ShellController bulletShell = CreateShellService.Instance.CreateBulletShell(fireTransform);

            bulletShell.GetShellView.AddVelocity(currentLaunchForce * fireTransform.forward);
            shootingAudio.clip = fireClip;
            shootingAudio.Play();
            currentLaunchForce = minLaunchForce;
        }
    }
}
