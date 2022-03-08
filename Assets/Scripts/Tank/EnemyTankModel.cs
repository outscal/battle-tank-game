using UnityEngine;

namespace Tank
{
    [System.Serializable]
    public class EnemyTankModel:TankModel
    {
        #region Serialized Data members

        [SerializeField] private AiAgentModel aiAgentModel;

        #endregion

        #region Constructors

        public EnemyTankModel() : base()
        {
            aiAgentModel = new AiAgentModel();
            _type = TankType.Enemy;
        }

        public EnemyTankModel(TankModel other) : base(other)
        {
            aiAgentModel = new AiAgentModel();
            _type = TankType.Enemy;
        }

        public EnemyTankModel(EnemyTankModel other) : base(other)
        {
            aiAgentModel = (other.AiAgentModel!=null)?new AiAgentModel(other.aiAgentModel):new AiAgentModel();
        }

        #endregion

        #region Getters

        public AiAgentModel AiAgentModel => aiAgentModel;

        #endregion
    }
}