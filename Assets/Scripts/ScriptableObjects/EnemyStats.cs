using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "PluggableAI/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {
        public float m_Movespeed = 1;
        public float m_lookRange = 40f;
        public float m_LookSpearCastRadius = 1f;

        public Rigidbody2D rigidbody2d;

        public float m_AttackRange = 1f;
        public float m_AttackRate = 1f;
        public float m_AttackForce = 15f;
        public float m_AttackTarget = 50;
    }
}