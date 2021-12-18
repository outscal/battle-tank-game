using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ground
{
    public class GroundCollider : MonoBehaviour
    {
        public static Collider groundBoxCollider;

        private void Awake()
        {
            groundBoxCollider = GetComponent<Collider>();
        }
    }
}
