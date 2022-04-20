using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T> 
{

	private static T instance;
	public T Instance { get { return instance; } }

	private void Awake() 
	{
        if (instance == null) 
		{
			instance = (T)this;
			DontDestroyOnLoad(instance);
		}
        else 
		{
			Destroy(this);
		}
	}
}
public class PlayerTank : MonoSingleton<PlayerTank> { }
public class EnemyTank : MonoSingleton<EnemyTank> { }
