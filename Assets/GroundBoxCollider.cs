using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoxCollider : MonoBehaviour
{
        public static BoxCollider groundBoxCollider;

        private void Awake()
        {
            groundBoxCollider = GetComponent<BoxCollider>();
        }
}
