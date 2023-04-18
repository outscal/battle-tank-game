using BattleTank.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.GenericObjectPool
{
    public class GenericObjectPool<T> : MonoBehaviour where T : Component
    {
        private Queue<T> itemQueue;
        private Dictionary<ObjectPoolType, Queue<T>> itemPool;
        [SerializeField] protected ObjectPoolType objectPoolType;
        [SerializeField] protected T itemPrefab;
        [SerializeField] protected int initialPoolSize;

        protected virtual void Start()
        {
            itemPool = new Dictionary<ObjectPoolType, Queue<T>>();
            itemQueue = new Queue<T>();
            itemPool.Add(objectPoolType, itemQueue);
            
            InitializePool();
        }

        private void InitializePool()
        {
            for(int i = 0; i < initialPoolSize; i++)
            {
                ReturnItem(objectPoolType, CreateNewItem());
            }
        }

        public T GetItem(ObjectPoolType _objectPoolType)
        {
            Queue<T> tempQueue = null;
            if (itemPool.TryGetValue(_objectPoolType, out tempQueue))
            {
                if(tempQueue.Count == 0)
                {
                    return CreateNewItem();
                }
                return tempQueue.Dequeue();
            }
            return null;
        }

        private T CreateNewItem()
        {
            T item = Instantiate<T>(itemPrefab);
            item.gameObject.SetActive(false);
            return item;
        }

        public void ReturnItem(ObjectPoolType _objectPoolType, T item)
        {
            Queue<T> tempQueue = null;
            item.gameObject.SetActive(false);
            if (itemPool.TryGetValue(_objectPoolType, out tempQueue))
            {
                tempQueue.Enqueue(item);
            }
        }
    }
}