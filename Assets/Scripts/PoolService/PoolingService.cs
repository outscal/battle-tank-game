using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingService<T> : MonoSingletonGeneric<PoolingService<T>> 
    where T : class
{


    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
    public virtual T GetItem()
    {
        Debug.Log("get item");
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(i => i.IsUsed == false);
            if (item != null)
            {
                item.IsUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        PooledItem<T> pooledItem = new PooledItem<T>();
        pooledItem.Item = CreateItem();
        pooledItem.IsUsed = true;
        pooledItems.Add(pooledItem);
        return pooledItem.Item;
    }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.IsUsed = false;
    }

    protected virtual T CreateItem()
    {
        return (T)null;
    }

    private class PooledItem<T>
    {
        public T Item;
        public bool IsUsed;
    }


}

