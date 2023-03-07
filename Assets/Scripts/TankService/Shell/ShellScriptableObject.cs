using UnityEngine;

namespace TankBattle.TankService.Bullets
{
    [CreateAssetMenu(fileName ="ShellScriptableObject", menuName ="ScriptableObjects/ShellBullet")]
    public class ShellScriptableObject : ScriptableObject
    {
        public ShellView shellView;
        public float explosionRadius;
        public float explosionForce;
        public LayerMask layerMask;
        public float maxDamage;
        public float maxLifeInSeconds;
    }
}
