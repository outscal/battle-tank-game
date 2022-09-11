using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameServices;

/// <summary>
/// This Class is Attached to a Player Tank GameObject and is responsible for UI related work.
/// </summary>

namespace TankServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        public Transform BulletSpawner;

        public GameObject turret;

        // To display aim arrow.
        public Transform fireTransform;

        private void Start()
        {
            SetPlayerTankColor();

            // Add's reference of tank position in camera targets list.
            CameraController.Instance.AddCameraTargetPosition(this.transform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tankController.DestroyWorld();
            }
        }

        public void SetTankControllerReference(TankController _tankController)
        {
            tankController = _tankController;
        }

        public void Death()
        {
            // Removes reference of tank position in camera targets list.
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            Destroy(gameObject);
        }

        // Implementation of IDamagable interface.
        public void TakeDamage(int damage)
        {
            tankController.TakeDamage(damage);
        }

        // Sets material color of all child mesh renderers.
        public void SetPlayerTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = tankController.tankModel.TankColor;
            }
        }
    }
}
