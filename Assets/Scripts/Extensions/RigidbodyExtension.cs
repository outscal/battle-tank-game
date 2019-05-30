using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class RigidbodyExtension
    {
        public static void Reset(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

    }
}