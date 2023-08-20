

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolSingleton<T> : GenericSingleton<ObjectPoolSingleton<T>> where T: class
{
    [SerializeField] protected Queue<T> availableItems = new Queue<T>();
    [SerializeField] protected List<T> inUseItems = new List<T>();

    #region public functions
    public virtual T getItem()
    {
        T item = (T)null;
        if (availableItems.Count < 1)
        {
            item = makeItem();
            inUseItems.Add(item);
            return item;
        }
        else
        {
            item = availableItems.Dequeue();
            inUseItems.Add(item);
            return item;
        }
    }



    public void retrieveItem( T _retreivedItem)
    {
        Debug.Log("reteriving bullet");
        foreach (T item in inUseItems)
        {
            Debug.Log("count in used itesm: " + inUseItems.Count);
            if (item.Equals(_retreivedItem))
            {
                Debug.Log("bullet returned");
                availableItems.Enqueue(item);
                inUseItems.Remove(item);
                break;
            }
        }
    }

    #endregion

    #region protected functions
    protected virtual T makeItem()
    {
        T availableItem = (T)null;
        return availableItem;
    } 
    #endregion


    protected class ObjectInfo 
    {
        public T item;
        public bool isUsed;
    }
}
