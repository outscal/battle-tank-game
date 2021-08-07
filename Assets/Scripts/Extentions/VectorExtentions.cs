using UnityEngine;

namespace Outscal.BattleTank 
{
    public static class VectorExtentions
    {

     public static Vector3 Setz(this Vector3 vector,float newZ)
        {
            return new Vector3(vector.x, vector.y, newZ);
        }
    }
}