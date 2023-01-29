using UnityEngine;

public class EnemyService : MonoBehaviour
{

    public EnemyView enemyView;
    public EnemyScriptaleObject[] enemyConfiguration;
    




    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
      

        int enemyToSpwan = Random.Range(1,3);

        Debug.Log("Enemy number" + enemyToSpwan);
        CreateNewEnemy(enemyToSpwan);

    }

    private EnemyController CreateNewEnemy(int index)
    {
        
        EnemyScriptaleObject enemyScriptableObject = enemyConfiguration[index];
        EnemyModel model = new EnemyModel(enemyScriptableObject);
        EnemyController enemy = new EnemyController(model, enemyView, this.gameObject.transform);
        return enemy;
        
    }
}
