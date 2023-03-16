using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankService : MonoBehaviour
{
    public Tank_View tankView;
    public TankScriptableObject[] tankConfigurations;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {

        int tankToSpawn = Random.Range(1, 3);

        Debug.Log("Tank number" + tankToSpawn);
        CreateNewTank(tankToSpawn);
        
    }

    private Tank_Ctrl CreateNewTank(int index)
    {
        TankScriptableObject tankscriptableobject = tankConfigurations[index];
        Tank_Model model = new Tank_Model(tankscriptableobject);
        Tank_Ctrl tank = new Tank_Ctrl(model, tankView);
        return tank;
    }
}
