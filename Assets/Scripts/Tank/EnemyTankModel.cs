using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Tank
{
    [System.Serializable]
    public class EnemyTankModel:TankModel
    {
        [SerializeField] private AiAgentModel aiAgentModel;
        
        public AiAgentModel AiAgentModel => aiAgentModel;

        public EnemyTankModel() : base()
        {
            aiAgentModel = new AiAgentModel();
        }

        public EnemyTankModel(TankModel other) : base(other)
        {
            aiAgentModel = new AiAgentModel();
        }

        public EnemyTankModel(EnemyTankModel other) : base(other)
        {
            aiAgentModel = (other.AiAgentModel!=null)?new AiAgentModel(other.aiAgentModel):new AiAgentModel();
        }
        
    }
}