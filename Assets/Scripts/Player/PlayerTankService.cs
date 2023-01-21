using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{

    public PlayerTankScriptableObjectList playerList;
    public Vector3 spawnArea;
    public PlayerTankController playerTankController;
    private BulletService bulletService;
    public BulletScriptableObjectList bulletScriptableObjectList;
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
        
        PlayerTankScriptableObject playerTankScriptableObject = playerList.pTanks[randomIndex];
        
        GameObject playerObject = Instantiate(playerTankScriptableObject.prefab);

        playerObject.transform.position = spawnArea;
        playerTankModel = new PlayerTankModel(playerTankScriptableObject, playerObject.transform);

        playerTankView = playerObject.GetComponent<PlayerTankView>();
        playerTankController = new PlayerTankController(playerTankModel, playerTankView);

        
    }

    public PlayerTankView GetView()
    {
        return playerTankView;
    }


}
