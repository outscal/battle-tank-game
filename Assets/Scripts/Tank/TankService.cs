using UnityEngine;

public class TankService : MonoBehaviour
{   
    [SerializeField]private int NoOfEnemies;
    [SerializeField]private ObjectPool objectPool;

    private void Start() {

        for(int i=0;i<NoOfEnemies;i++){
             //spawnNewTank();
             //objectPool.spawner("EnemyTank");
        }
    }

    #region PUBLIC METHODS

        public void spawnNewTank(){

            //TankScriptableObject tankScriptableObject = tankConfiguration[type];

            // float xLocation = UnityEngine.Random.Range(-30,36);             
            // float zLocation = UnityEngine.Random.Range(-41,40);
            //Vector3 location = new Vector3(xlocation,0f,zLocation);   

            //objectPool.spawner();
        }

    #endregion

}
