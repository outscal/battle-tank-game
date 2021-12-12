using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static T _instance;
    public static  T _Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
        }
        else
        {
            Destroy(this);
        }
    }
}

public class PlayerTank : Singleton<PlayerTank>
{
    [SerializeField] private float speed;
    [SerializeField] FixedJoystick joystick;

    PlayerTank(PlayerTank p, FixedJoystick js)
    {
        //Speed = speed;
        js = joystick;
       // p = gameObject.AddComponent<mode>()
        js = gameObject.AddComponent<FixedJoystick>();
    }

}

public class EnemyTank : Singleton<EnemyTank>
{

}
