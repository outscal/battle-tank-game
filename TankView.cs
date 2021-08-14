using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private CharacterController charController;

        [SerializeField]
        private float movement_Speed = 3f;

        [SerializeField]
        private float gravity = 9.8f;

        [SerializeField]
        private float rotation_Speed = 0.15f;

        [SerializeField]
        private float rotateDegreesPerSecond = 180f;

        [SerializeField]
        private GameObject shell;

        [SerializeField]
        private Transform fireTransform;

        [SerializeField]
        private float m_LaunchForce;

        [SerializeField]
        private TankController tankController;

        private void Awake()
        {
            charController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            tankController.Move(transform, gravity, charController);
            tankController.Rotate(transform, rotateDegreesPerSecond);
            tankController.Fire(shell, fireTransform, m_LaunchForce);
        }
    }
}
