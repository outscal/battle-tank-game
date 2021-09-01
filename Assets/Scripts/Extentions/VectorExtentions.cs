using UnityEngine;

namespace Outscal.BattleTank 
{
    public static class VectorExtentions
    {

     public static Vector3 Setz(this Vector3 vector,float newZ)
        {
            return new Vector3(vector.x, vector.y, newZ);
        }

        public static Vector3 SetX(this Vector3 vector,float newX)
        {
            return new Vector3(newX, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector,float newY)
        {
            return new Vector3(vector.x, newY, vector.z);
        }
    }
}