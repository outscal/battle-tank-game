using UnityEngine;

namespace Tank
{
    [System.Serializable]
    public class EnemyTankModel:TankModel
    {
        [SerializeField] private AiAgentModel aiAgentModel;
        
        public AiAgentModel AiAgentModel => aiAgentModel;

        public EnemyTankModel(TankModel other) : base(other)
        {
            aiAgentModel = new AiAgentModel();
        }

        public EnemyTankModel(EnemyTankModel other) : base(other)
        {
            aiAgentModel = new AiAgentModel(other.aiAgentModel);
        }
    }
}