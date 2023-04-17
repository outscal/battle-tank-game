using BattleTank.PlayerTank;
using BattleTank.Services;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class CollectibleTankObject : MonoBehaviour
    {
        [SerializeField] private List<MeshRenderer> tankRenderer;
        [SerializeField] private int additionalHealthPercentage;
        [SerializeField] private int rotationValue;
        [SerializeField] private int rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.up, rotationValue * rotationSpeed);
        }

        public void UpdateCollectibleTankColor(Material _material)
        {
            for (int i = 0; i < tankRenderer.Count; i++)
            {
                tankRenderer[i].material = _material;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerTankView>() != null)
            {
                gameObject.SetActive(false);
                PlayerTankService.Instance.GetPlayerTankController().SetArrowObjectActive(false);
                other.GetComponent<PlayerTankView>().AddAdditionalHealth(additionalHealthPercentage);
            }
        }
    }
}