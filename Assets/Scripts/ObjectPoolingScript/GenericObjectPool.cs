using System.Collections.Generic;

namespace BattleTank.Generics
{
    public class GenericObjectPool<T> : GenericSingleton<GenericObjectPool<T>> where T : class
    {
        private List<PooledItem<T>> pooledItems;

        public virtual T GetItem()
        {
            if (pooledItems.Count < 0)
                return null;

            PooledItem<T> pooledItem = pooledItems.Find(newItem => newItem.isUsed == false);
            if (pooledItem != null)
            {
                pooledItem.isUsed = true;
                return pooledItem.item;
            }

            PooledItem<T> newPoolItem = new PooledItem<T>();
            newPoolItem.item = CreateItem();
            newPoolItem.isUsed = false;
            pooledItems.Add(newPoolItem);
            return newPoolItem.item;
        }

        public virtual void ReturnItem(T item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(newItem => newItem.item == item);
            if (pooledItem != null)
                pooledItem.isUsed = false;
        }

        public T CreateItem()
        {
            return (T)null;
        }
    }

    public class PooledItem<T>
    {
        public T item;
        public bool isUsed;
    }
}
