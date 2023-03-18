﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T: GenericSingleton<T> {

	private static T instance;
	public static T Instance { get { return instance; } }

	protected virtual void Awake()
    {
		if(instance == null)
        {
            instance = (T)this;
            Debug.Log("Singleton");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
