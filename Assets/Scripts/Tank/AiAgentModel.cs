using UnityEngine;

namespace Tank
{
    [System.Serializable]
    public class AiAgentModel
    {
        #region Serialized Data members

        [SerializeField] private float radarRange = 20;
        [SerializeField] private float attackRange = 10;
        [SerializeField] private float refreshTime = 5;
        [SerializeField] private float fireRate = 1;

        #endregion

        #region Constructors

        public AiAgentModel(AiAgentModel other)
        {
            radarRange = other.RadarRange;
            refreshTime = other.RefreshTime;
            attackRange = other.AttackRange;
            fireRate = other.FireRate;
        }

        public AiAgentModel() {}

        #endregion

        #region Getters

        public float RadarRange => radarRange;
        public float AttackRange => attackRange;
        public float RefreshTime => refreshTime;

        public float FireRate => fireRate;

        #endregion
    }
}