using BattleTank.GenericSingleton;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.GenericObjectPool
{
    public class GenericObjectPool<T> : GenericSingleton<GenericObjectPool<T>> where T : Component
    {
        private Stack<T> itemPool;
        protected T itemPrefab;
        protected int initialPoolSize;

        protected virtual void Start()
        {
            itemPool = new Stack<T>();
            SetItemPrefab();
            SetInitialPoolSize();
            InitializePool();
        }

        private void InitializePool()
        {
            for(int i = 0; i < initialPoolSize; i++)
            {
                ReturnItem(CreateNewItem());
            }
        }

        public T GetItem()
        {
            if(itemPool.Count == 0)
            {
                return CreateNewItem();
            }
            return itemPool.Pop();
        }

        private T CreateNewItem()
        {
            T item = Instantiate<T>(itemPrefab);
            item.gameObject.SetActive(false);
            return item;
        }

        public void ReturnItem(T item)
        {
            item.gameObject.SetActive(false);
            itemPool.Push(item);
        }

        protected virtual void SetItemPrefab() { }
        protected virtual void SetInitialPoolSize() { }
    }
}