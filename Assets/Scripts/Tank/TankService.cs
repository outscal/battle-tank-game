using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField]
    private TankScriptableObject[] tankConfiguration;
    [SerializeField]
    private GameObject _tankPrefab;

    private void Start() {
        // for(int i=0;i<4;i++){
        //     float xLocation = Random.Range(-30,36);
        //     float zLocation = Random.Range(-41,40);
        //     Vector3 location = new Vector3(xLocation,0,zLocation);
        //     SpawnNewTankAtPosition(location,i);
        // }
    }

    #region PUBLIC METHODS

        public void SpawnNewTankAtPosition(Vector3 spawnPosition,int type){

            TankScriptableObject tankScriptableObject = tankConfiguration[type];
            GameObject Enemytank = Instantiate(_tankPrefab,spawnPosition,Quaternion.identity);
        }

    #endregion

}
