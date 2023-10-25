using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleTank
{
    public class ServicePool<T> : MonoSingletonGeneric<ServicePool<T>> where T : class
    {
        private List<PooledItems<T>> pooledItems = new List<PooledItems<T>>();

        public virtual T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItems<T> item = pooledItems.Find(i => i.IsUsed == false);
                if (item != null)
                {
                    item.IsUsed = true;
                    return item.Items;
                }
                return CreateNewPooledItem();

            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItems<T> pooledItem = new PooledItems<T>();
            pooledItem.Items = CreateItem();
            pooledItem.IsUsed = true;
            pooledItems.Add(pooledItem);
            Debug.Log("New Item added to the Pool:" + pooledItems.Count);
            return pooledItem.Items;
        }
        protected virtual T CreateItem()
        {
            return (T)null;
        }

        public virtual void ReturnItems(T item)
        {
            PooledItems<T> pooledItem = pooledItems.Find(i => i.Items.Equals(item));
            pooledItem.IsUsed = false;
            Debug.Log("Returning to the Pool");
        }

        public class PooledItems<T>
        {
            public T Items;
            public bool IsUsed;
        }
    }


}