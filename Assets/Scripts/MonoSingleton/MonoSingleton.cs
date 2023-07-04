using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {

    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake() {
        if (instance != null) {
            Destroy(gameObject);

        } else {
            instance = (T)this;
        }
    }

}
