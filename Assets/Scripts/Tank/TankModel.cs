using UnityEngine;

namespace Tank
{
    public class TankModel
    {
        public TankModel(int speed, float health, float m_TurnSpeed, int m_PlayerNumber, float m_PitchRange, float bulletLaunchForce, KeyCode fireKey)
        {
            Speed = speed;
            Health = health;
            M_TurnSpeed = m_TurnSpeed;
            M_PlayerNumber = m_PlayerNumber;
            M_PitchRange = m_PitchRange;
            BulletLaunchForce = bulletLaunchForce;
            FireKey = fireKey;
        }

        public int Speed { get; }
        public float Health { get; }
        public int M_PlayerNumber { get; }
        public float M_PitchRange { get; }
        public float BulletLaunchForce { get; }
        public KeyCode FireKey { get; }
        public float M_TurnSpeed { get; }
    }
}
