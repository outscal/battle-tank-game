using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolService<T> : SingletonGeneric<PoolService<T>> where T : class
{

    private class PooledItem<t>
    {
        public t Item;
        public bool IsUsed;
    }
    private List<PooledItem<T>> pooledItems = new();

    public virtual T GetItem()
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(x => x.IsUsed == false);
            if (item != null)
            {
                item.IsUsed = true;
                return item.Item;
            }
        }
        return CreateNewItem();
    }

    protected T CreateNewItem()
    {
        PooledItem<T> item = new()
        {
            Item = CreateItem(),
            IsUsed = true
        };
        pooledItems.Add(item);
        return item.Item;
    }

    protected virtual T CreateItem() { return null; }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> usedItem = pooledItems.Find(x => x.Item.Equals(item));
        usedItem.IsUsed = false;
    }









}
