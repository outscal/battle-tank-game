using UnityEngine;

public class PlayerTankFactory : MonoBehaviour
{
     public PlayerTankScriptableObjectList playerList;
    public Vector3 spawnArea;
    public PlayerTankController playerTankController;
    private BulletService bulletService;
    public BulletScriptableObjectList bulletScriptableObjectList;
    private Transform bulletSpawnPoint;
    public PlayerTankModel playerTankModel;


    public void CreateNewPlayerTank()
    {
        int randomIndex = Random.Range(0, playerList.pTanks.Length);
        int randomBulletIndex = Random.Range(0, bulletScriptableObjectList.BulletList.Length);
        PlayerTankScriptableObject playerTankScriptableObject = playerList.pTanks[randomIndex];
        BulletScriptableObject bulletScriptableObject = bulletScriptableObjectList.BulletList[randomBulletIndex];
        GameObject playerObject = Instantiate(playerTankScriptableObject.prefab);

        playerObject.transform.position = spawnArea;
        bulletSpawnPoint = playerObject.transform; // Assign live position and rotation to bulletSpawnPoint
        playerTankModel = new PlayerTankModel(playerTankScriptableObject, playerObject.transform);

        PlayerTankView playerTankView = playerObject.GetComponent<PlayerTankView>();
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);
    }
}
