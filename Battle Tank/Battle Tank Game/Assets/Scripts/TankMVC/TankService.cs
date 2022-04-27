using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField]public TankView tankView;
    CameraControl cameraControl;

    //public TankScriptableObject[] tankConfigurations;
    public TankScriptableObjectList tankList;    

    // Start is called before the first frame update

    void Start()
    {
        //tankView.gameObject.SetActive(true);
        StartGame();
        //cameraControl.SetStartPositionAndSize();
    }

    void StartGame()
    {
        
        CreatePlayerTank();
        //CreateEnemyTank();
    }

    private void CreatePlayerTank()
    {
       int index = Random.Range(0, tankList.tanks.Length);
        TankScriptableObject tankScriptableObject = tankList.tanks[index];
        TankModel tankModel = new TankModel(tankScriptableObject);
        Debug.Log("Created " + tankScriptableObject.tankName);
        // TankModel tankModel = new TankModel(TankType.none, 15, 50);
        TankController tankController = new TankController(tankModel, tankView);         
    }
    // private void CreateEnemyTank()
    // {
    //    int index = Random.Range(0, tankList.tanks.Length);
    //     TankScriptableObject tankScriptableObject = tankList.tanks[index];
    //     TankModel tankModel = new TankModel(tankScriptableObject);
    //     Debug.Log("Created " + tankScriptableObject.tankName);
    //     tankView.transform.position = new Vector3 (0f, 0f, -10f);
    //     Quaternion turnRotation = Quaternion.Euler(0f, 90f, 0f);
    //     tankView.rb.MoveRotation(tankView.rb.rotation * turnRotation);
    //     // TankModel tankModel = new TankModel(TankType.none, 15, 50);
    //     TankController tankController = new TankController(tankModel, tankView);            
    // }
}
