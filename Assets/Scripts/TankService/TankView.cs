using UnityEngine;

namespace TankBattle.TankService
{
    [RequireComponent(typeof(Rigidbody))]

    public class TankView : MonoBehaviour
    {
        [SerializeField] private Color color;

        private MeshRenderer[] rendererArray;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            
            rendererArray = GetComponentsInChildren<MeshRenderer>();

            SetColorOnAllRenderers();
        }

        public void SetColorOnAllRenderers()
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