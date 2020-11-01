using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingeltonGeneric<T> : MonoBehaviour where T:MonoSingeltonGeneric<T>
{
  private static T instance;
  public static T Instance{get{return instance;}}
  
  private void Awake() {
      if(instance==null){
          instance = (T)this;
      }
      else{
          Destroy(this);
      }
  }
}
