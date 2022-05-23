using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public ETankView EnemyTankView;
    private ETankModel EnemyTankModel;
    public int numOfEnemies;

    //public Transform spawnEnemy;

    public TankScriptableObjectList tankScriptableObjectList;

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            CreateEnemyTank();
        }
    }
    Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 pos;
        x = Random.Range(-35, 35);
        y = 1;
        z = Random.Range(-20, 30);
        pos = new Vector3(x, y, z);
        return pos;
    }

    private ETankController CreateEnemyTank()
    {
        int index = Random.Range(0, tankScriptableObjectList.TankSOList.Length);
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.TankSOList[index];
        //Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        EnemyTankModel = new ETankModel(tankScriptableObject);
        ETankController enemyTank = new ETankController(EnemyTankModel, EnemyTankView, RandomPosition());
        return enemyTank;
    }

}

