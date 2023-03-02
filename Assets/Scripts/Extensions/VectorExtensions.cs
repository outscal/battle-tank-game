using UnityEngine;

namespace TankBattle.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 vector2ToVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, 0, vector.y);
        }
    }
}