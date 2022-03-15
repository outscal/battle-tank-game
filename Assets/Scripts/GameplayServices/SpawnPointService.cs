using GlobalServices;
using UnityEngine;

namespace GameplayServices
{
    public class SpawnPointService : MonoSingletonGeneric<SpawnPointService>
    {
        [SerializeField] private Transform playerSpawnPoint;

        [SerializeField] private Transform[] quarter1 = new Transform[4];
        [SerializeField] private Transform[] quarter2 = new Transform[4];
        [SerializeField] private Transform[] quarter3 = new Transform[4];
        [SerializeField] private Transform[] quarter4 = new Transform[4];

        public Transform GetRandomSpawnPoint()
        {
            int quarterNumber = Random.Range(1, 4);
            int transformNumber = Random.Range(0, 3);

            switch (quarterNumber)
            {
                case 1:
                    return quarter1[transformNumber];

                case 2:
                    return quarter2[transformNumber];

                case 3:
                    return quarter3[transformNumber];

                case 4:
                    return quarter4[transformNumber];
            }

            return quarter1[transformNumber];
        }

        public Transform GetPlayerSpawnPoint()
        {
            return playerSpawnPoint;
        }
    }
}
