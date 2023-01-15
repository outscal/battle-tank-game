using UnityEngine;

public class PlayerTankService : MonoBehaviour
{
    public PlayerTankScriptableObjectList playerList;
    public Vector3 spawnArea;
    public PlayerTankController playerTankController;
    public BulletService bulletService;
    public BulletScriptableObject bulletScriptableObject;

    private void Start()
    {
        CreateNewPlayerTank();
    }

    public void Update()
    {
        playerTankController.Update();
    }
    public void CreateNewPlayerTank()
    {
        int randomIndex = Random.Range(0, playerList.pTanks.Length);
        PlayerTankScriptableObject playerTankScriptableObject = playerList.pTanks[randomIndex];
        GameObject playerObject = Instantiate(playerTankScriptableObject.prefab);
        playerObject.transform.position = spawnArea;
        PlayerTankModel playerTankModel = new PlayerTankModel(playerTankScriptableObject, playerObject.transform, bulletService, bulletScriptableObject);
        PlayerTankView playerTankView = playerObject.GetComponent<PlayerTankView>();
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);

    }

}
