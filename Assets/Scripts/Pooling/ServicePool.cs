using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePool<T> : MonoSingeltonGeneric<ServicePool<T>> where T: class
{
    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    public virtual T GetItem()
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(i => i.isUsed == false);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
            return CreateNewPooledItem();
        }
        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        PooledItem<T> pooledItem = new PooledItem<T>();
        pooledItem.Item = CreateItem();
        pooledItem.isUsed = true;
        pooledItems.Add(pooledItem);
        return pooledItem.Item;
    }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.isUsed = false;
    }

    protected virtual T CreateItem()
    {
        return (T)null;
    }

    private class PooledItem<T>
    {
        public T Item;
        public bool isUsed;
    }
}


