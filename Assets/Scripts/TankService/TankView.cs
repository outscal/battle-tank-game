using UnityEngine;

namespace TankBattle.TankService
{
    [RequireComponent(typeof(Rigidbody))]


    //  Cannot change color in tankService 
    // might be due to runtime constraints or some shit.
    public class TankView : MonoBehaviour
    {

        private MeshRenderer[] rendererArray;
        private Rigidbody rb;
        private Color color;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            
            rendererArray = GetComponentsInChildren<MeshRenderer>();
        }

        public void SetColor(Color _color)
        {
            for (int i = 0; i < rendererArray.Length; i++)
            {
                rendererArray[i].material.color = color;
            }
        }

        public void changeColor()
        {

        }

        public Rigidbody getRigidbody()
        {
            return rb;
        }
    }
}