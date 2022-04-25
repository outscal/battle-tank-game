using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePool<T> : SingletonGeneric<ServicePool<T>>
where T : class
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
                return item.Item;
            }
        }
        return CreateNewPooledItem();

    }
    private T CreateNewPooledItem()
    {
        PooledItems<T> pooledItem = new PooledItems<T>();
        pooledItem.Item = CreateItem();
        pooledItem.IsUsed = true;
        pooledItems.Add(pooledItem);
        Debug.Log("new tank created" + pooledItems.Count);
        return pooledItem.Item;

    }
    public virtual void ReturnItem(T item)
    {
        PooledItems<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.IsUsed = false;
    }
    protected virtual T CreateItem()
    {
        return (T)null;
    }
}

class PooledItems<T>
{
    public T Item;
    public bool IsUsed;
}