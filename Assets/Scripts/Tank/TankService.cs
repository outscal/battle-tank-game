using UnityEngine;

public class TankService : MonoBehaviour
{   
    [SerializeField]private int NoOfEnemies;
    [SerializeField]private ObjectPool objectPool;

    private void Start() {

        for(int i=0;i<NoOfEnemies;i++){
             //spawnNewTank();
             objectPool.spawner();
        }
    }

    #region PUBLIC METHODS

        public void spawnNewTank(){

            //TankScriptableObject tankScriptableObject = tankConfiguration[type];
            //objectPool.spawner();
        }

    #endregion

}
