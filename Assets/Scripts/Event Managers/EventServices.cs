using System;

public class EventServices
{
	private static EventServices instance;
	public static EventServices Instance
	{
		get
		{
			if (instance == null)
				instance = new EventServices();
			return instance;
		}
	}

	public Action<int> OnEnemyDeath;
	public Action<int> OnShellFired;
}

