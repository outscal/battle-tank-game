using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{

    public PlayerTankScriptableObjectList playerList;
    public Vector3 spawnArea;
    public PlayerTankController playerTankController;
    private BulletService bulletService;
    public BulletScriptableObjectList bulletScriptableObjectList;
    private Transform bulletSpawnPoint;
    public PlayerTankModel playerTankModel;
    public EnemyService enemyService;

    private PlayerTankView playerTankView;


    private void Start()
    {
        enemyService = FindObjectOfType<EnemyService>();

        if (bulletScriptableObjectList != null)
        {
            bulletService = new BulletService(bulletScriptableObjectList);
        }

        CreateNewPlayerTank();
    }


    public void Update()
    {
        if (playerTankController != null)
            playerTankController.Update();
    }

    public void CreateNewPlayerTank()
    {
        int randomIndex = Random.Range(0, playerList.pTanks.Length);
        int randomBulletIndex = Random.Range(0, bulletScriptableObjectList.BulletList.Length);
        PlayerTankScriptableObject playerTankScriptableObject = playerList.pTanks[randomIndex];
        BulletScriptableObject bulletScriptableObject = bulletScriptableObjectList.BulletList[randomBulletIndex];
        GameObject playerObject = Instantiate(playerTankScriptableObject.prefab);

        playerObject.transform.position = spawnArea;
        bulletSpawnPoint = playerObject.transform; // Assign live position and rotation to bulletSpawnPoint
        playerTankModel = new PlayerTankModel(playerTankScriptableObject, playerObject.transform, bulletScriptableObject, bulletSpawnPoint);

        playerTankView = playerObject.GetComponent<PlayerTankView>();
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);
    }

    public PlayerTankView GetView()
    {
        return playerTankView;
    }


}
