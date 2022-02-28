using UnityEngine;

namespace Tank
{
    [System.Serializable]
    public class AiAgentModel
    {
        [SerializeField] private float range = 20;
        [SerializeField] private float refreshTime = 5;
        public float Range => range;
        public float RefreshTime => refreshTime;
        
        public AiAgentModel(){}

        public AiAgentModel(AiAgentModel other)
        {
            range = other.Range;
            refreshTime = other.RefreshTime;
        }
    }
}