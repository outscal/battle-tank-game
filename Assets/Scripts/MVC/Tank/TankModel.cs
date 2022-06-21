using UnityEngine;
using UnityEngine.UI;

public class TankModel 
{
    private TankController tankController;

    public float movementSpeed;
    public float rotateSpeed;
    public TankTypeEnum tankType;
    public string tankName;
    public float startHealth;
    public float maxHealth;
    public Slider m_Slider;
    public Color m_FullHealthColor = Color.Green;
    public Color m_ZeroHealthColor = Color.Red;
    public GameObject m_ExplosionPrefab;



    public TankModel(TankScriptableObject tankScriptableObject)
    {
       tankType = tankScriptableObject.TankType;
       movementSpeed = tankScriptableObject.speed;
       rotateSpeed = tankScriptableObject.rspeed;
       tankName = tankScriptableObject.TankName;
       health = tankScriptableObject.startHealth;
       maxhealth = tankScriptableObject.maxHealth;
       
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }
}
