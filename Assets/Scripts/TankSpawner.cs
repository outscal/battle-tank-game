using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerTank;
    [SerializeField] GameObject enemyTankPrefab;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject enemyTanks;
    [SerializeField] TankScriptableObjectList allPlayerTanks;
    [SerializeField] EnemyTankScriptableObjectList allEnemyTanks;
    void Start()
    {
        int selectPlayer = UnityEngine.Random.Range(0, allPlayerTanks.Tanks.Length);
        TankScriptableObject playerTSO = allPlayerTanks.Tanks[selectPlayer];
        playerTank.GetComponent<TankController>().SetPlayerTank(playerTSO);
        for(int i=0;i<spawnPositions.Length;i++)
        {
            GameObject enemyTank = Instantiate(enemyTankPrefab, spawnPositions[i].position, Quaternion.identity) as GameObject;
            enemyTank.transform.parent = enemyTanks.transform;
            enemyTank.GetComponent<EnemyTankController>().SetEnemyTank(allEnemyTanks.EnemyTanks[i]);
        }
    }

  

    void Update()
    {
        
    }
}
