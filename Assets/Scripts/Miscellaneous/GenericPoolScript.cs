using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class GenericPoolScript<T>
    {
        private static GenericPoolScript<T> instance;
        public static GenericPoolScript<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new GenericPoolScript<T>();
                return instance;
            }
        }
        Queue<T> poolQueue = new Queue<T>();
        T tempVar;

        public void Enqueue(T tempObj)
        {
            poolQueue.Enqueue(tempObj);
        }

        public T Dequeue()
        {
            tempVar = poolQueue.Peek();
            poolQueue.Dequeue();
            return tempVar;
        }


    }

}
