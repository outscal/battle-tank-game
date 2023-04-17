using BattleTank.GenericSingleton;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Services
{
    public class CollectibleService : GenericSingleton<CollectibleService>
    {
        [SerializeField] private CollectibleTankObject collectibleTankPrefab;
        [SerializeField] private float halfPercentage;
        [SerializeField] private float spawnRange;
        [SerializeField] private float defaultYAxis;
        private CollectibleTankObject collectibleTankGameObject;

        protected override void Awake()
        {
            base.Awake();
            collectibleTankGameObject = Instantiate(collectibleTankPrefab);
            collectibleTankGameObject.gameObject.SetActive(false);
        }

        public void UpdateCollectibleTankMaterial(Material _material)
        {
            collectibleTankGameObject.UpdateCollectibleTankColor(_material);
        }

        public Transform GetCollectibleObjectTransform()
        {
            return collectibleTankGameObject.transform;
        }

        public Vector3 GetSpawnPosition()
        {
            bool pointFound = false;
            Vector3 finalPosition = Vector3.zero;
            NavMeshHit hit;

            while (pointFound != true)
            {
                Vector3 randomDirection = gameObject.transform.position + spawnRange * Random.insideUnitSphere;

                if (NavMesh.SamplePosition(randomDirection, out hit, 1, NavMesh.AllAreas))
                {
                    finalPosition = hit.position;
                    pointFound = true;
                }
            }

            return finalPosition;
        }

        public void LowHealth()
        {
            if (!collectibleTankGameObject.gameObject.activeSelf)
            {
                collectibleTankGameObject.transform.position = GetSpawnPosition();
                collectibleTankGameObject.transform.position = new Vector3(collectibleTankGameObject.transform.position.x, defaultYAxis, collectibleTankGameObject.transform.position.z);
                collectibleTankGameObject.gameObject.SetActive(true);
            }
        }
    }
}