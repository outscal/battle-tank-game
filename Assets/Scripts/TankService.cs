using UnityEngine;

public class TankService : MonoBehaviour
{
    public Tank_View tankView;
    public Tank_Ctrl tankctrl;
    Tank_Model tankModel;
    public TankScriptableObject[] tankConfigurations;

    public static TankService instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    public Transform PlayerPosition() {  return tankctrl.Playerpos(); }

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
        tankctrl = new Tank_Ctrl(model, tankView);
        return tankctrl;
    }
}
