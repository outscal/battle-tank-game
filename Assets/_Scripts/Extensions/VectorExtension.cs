using UnityEngine;
public static class VectorExtension 
{
    public static Vector3 SetZ(this Vector3 vector, float newZ)
    {
        return new Vector3(vector.x, vector.y, newZ );
    }
    public static Vector3 RemoveYZ(this Vector3 vector)
    {
        return new Vector3(vector.x, 0f, 0f );
    }


}
