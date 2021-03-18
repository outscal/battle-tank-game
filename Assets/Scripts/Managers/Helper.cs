using System.Linq;
using UnityEngine;

public static class Helper
{
    public static GameObject FindInChildren(this GameObject go, string name)
    {
        return (from x in go.GetComponentsInChildren<Transform>()
                where x.gameObject.name == name
                select x.gameObject).First();
    }
}
