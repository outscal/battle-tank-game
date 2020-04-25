using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T: MonoSingletonGeneric<T>
{
	private static T instance;
	public static T Instance { get { return instance; } }

	protected virtual void Awake()
	{
		if(instance == null)
		{
			instance = (T)this;
		}
		else
		{
			Debug.LogError("Someone trying to create a duplicate singleton");
			Destroy(this);
		}
	}
}

public class GameWorldNew : MonoSingletonGeneric<GameWorldNew>
{
	protected override void Awake()
	{
		base.Awake();
        //custom logic
	}

	public  void StartGameNew()
	{
		
	}
}

public class WorldNew : MonoBehaviour
{
	private void Start()
	{
		GameWorldNew.Instance.StartGameNew();
	}
}