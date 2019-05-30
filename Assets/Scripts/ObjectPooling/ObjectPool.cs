using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using System;

namespace ObjectPooling
{
    public class ObjectPool<T> : IPool where T : IPoolable, new()
    {
        public List<T> poolables = new List<T>();

        public T GetFromPool<OB>() where OB : T,new ()
        {
            T poolObj = default(T);

            if(poolables.Count <= 0)
            {
                poolObj = (T)new OB();
            }
            else
            {
                foreach (T obj in poolables)
                {
                    if(obj is OB)
                    {
                        poolObj = obj;
                        poolables.Remove(obj);
                        break;
                    }
                    else
                        poolObj = (T)new OB();
                }
            }

            return poolObj;
        }


        public void ReturnObjToPool(T poolObject)
        {
            //Debug.Log("<color=green>[ObjectPooling]</color> Adding Object to pool");
            poolables.Add(poolObject);
        }
    }

}