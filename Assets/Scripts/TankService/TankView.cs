using UnityEngine;

namespace TankBattle.Tank.View
{
    [RequireComponent(typeof(Rigidbody))]

    public class TankView : MonoBehaviour
    {
        //[SerializeField] private Color color;

        private MeshRenderer[] rendererArray;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rendererArray = GetComponentsInChildren<MeshRenderer>();
        }

        public void SetColorOnAllRenderers(Color color)
        {
            for (int i = 0; i < rendererArray.Length; i++)
            {
                rendererArray[i].material.color = color;
            }
        }

        public Rigidbody getRigidbody()
        {
            return rb;
        }
    }
}