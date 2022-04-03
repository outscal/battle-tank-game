using GlobalServices;
using UnityEngine;

namespace GameplayServices
{
    public class SpawnPointService : MonoSingletonGeneric<SpawnPointService>
    {
        [SerializeField] private Transform playerSpawnPoint;

        public Vector3 GetRandomSpawnPoint()
        {
            int Zpos = Random.Range(-30, 30);
            int Xpos = Random.Range(-30, 30);
            Vector3 enemyPos = new Vector3(Xpos, 0, Zpos);

            return enemyPos;
        }



        public Transform GetPlayerSpawnPoint()
        {
            return playerSpawnPoint;
        }
    }
}
