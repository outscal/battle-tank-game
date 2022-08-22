using UnityEngine;

namespace GameServices
{
    // To get random spawn transform for tanks.
    public class TankSpawnPointService : GenericSingleton<TankSpawnPointService>
    {
        // Player tank spawn transform.
        [SerializeField] private Transform playerSpawnPoint;

        // Enemy tank spawn transforms.
        [SerializeField] private Transform[] area1 = new Transform[3];
        [SerializeField] private Transform[] area2 = new Transform[3];
        [SerializeField] private Transform[] area3 = new Transform[3];
        [SerializeField] private Transform[] area4 = new Transform[3];

        // Returns random spawn transform.
        public Transform GetRandomSpawnPoint()
        {
            int areaNumber = Random.Range(1, 3);
            int transformNumber = Random.Range(0, 2);

            switch (areaNumber)
            {
                case 1:
                    return area1[transformNumber];

                case 2:
                    return area2[transformNumber];

                case 3:
                    return area3[transformNumber];

                case 4:
                    return area4[transformNumber];
            }

            return area1[transformNumber];
        }

        public Transform GetPlayerSpawnPoint()
        {
            return playerSpawnPoint;
        }
    }
}

