using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField]
    private TankScriptableObject[] tankConfiguration;
    [SerializeField]
    private GameObject _tankPrefab;


    #region PRIVATE METHODS

        #region UPDATE
            private void Update() {
                
            }
        #endregion
        
        private void CreateNewTankatPosition(Vector3 spawnPosition,int type){

            TankScriptableObject tankScriptableObject = tankConfiguration[type];
            TankController tankController = new TankController(tankScriptableObject);
            GameObject tank = Instantiate(_tankPrefab,spawnPosition,Quaternion.identity);

        }

    #endregion

}
