using UnityEngine;






[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Scriptableobject/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankTypeEnum TankType;
        public string TankName;
        public float StartingHealth;
        public float damage;
        public float speed;
        public float rspeed;
        public Color color;


    }

    
    

