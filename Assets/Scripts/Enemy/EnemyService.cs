using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyService : MonoBehaviour
{
    public EnemyTankScriptableObjectList enemyList;
    public Vector3[] spawnAreas;
    public PlayerTankModel playerTankModel;

    private int spawnIndex;
    public float spawnInterval = 2f;
    private WaitForSeconds spawnWait;
    public float chaseDistance;


    private void Start()
    {
        playerTankModel = PlayerTankService.Instance.playerTankModel;
        spawnWait = new WaitForSeconds(spawnInterval);

        StartCoroutine(WaitForPlayer());
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(1f);
        while (playerTankModel == null)
        {
            playerTankModel = PlayerTankService.Instance.playerTankModel;
            yield return new WaitForSeconds(0f);
        }
        while (true)
        {
            CreateNewEnemy();
            yield return spawnWait;
        }
    }

    public void CreateNewEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.eTanks.Length);
        EnemyTankScriptableObject enemyTankScriptableObject = enemyList.eTanks[randomIndex];
        GameObject enemyObject = Instantiate(enemyTankScriptableObject.prefab);
        enemyObject.transform.position = spawnAreas[spawnIndex];
        EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
        EnemyView enemyView = enemyObject.GetComponent<EnemyView>();
        PlayerTankView playerTankView = PlayerTankService.Instance.GetView();
        EnemyController enemyController = new EnemyController(playerTankView, enemyModel, enemyView, enemyObject.transform, chaseDistance);
        enemyView.enemyController= enemyController;
        enemyController.navMeshAgent = enemyView.GetComponent<NavMeshAgent>();
        spawnIndex++;
        if (spawnIndex >= spawnAreas.Length)
        {
            spawnIndex = 0;
        }
        
    }
}
