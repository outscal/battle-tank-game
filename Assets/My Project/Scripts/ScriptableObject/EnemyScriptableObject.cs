using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private float damageDealt;
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float aIShootingDistance;
        [SerializeField] private float aIVisibilityRadius;
        [SerializeField] private float shootCoolDown;
        [SerializeField] private int Strength;
        [SerializeField] private EnemyView EnemyTank;

        public float DamageDealt { get => damageDealt; set => damageDealt = value; }
        public float Speed { get => speed; set => speed = value; }
        public float Health { get => health; set => health = value; }
        public float AIShootingDistance { get => aIShootingDistance; set => aIShootingDistance = value; }
        public float AIVisibilityRadius { get => aIVisibilityRadius; set => aIVisibilityRadius = value; }
        public float ShootCoolDown { get => shootCoolDown; set => shootCoolDown = value; }
        public int strength { get => Strength; set => Strength = value; }
        public EnemyView enemyView { get => EnemyTank; set => EnemyTank = value; }
    }
}