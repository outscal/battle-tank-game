using System.Collections.Generic;

namespace AllServices
{
    [System.Serializable]
    public class ObjectPoolItem<T>
    {
        public T item;
        public bool b_IsUsed;
    }

    public class ObjectPoolingService<T> : GenericSingleton<ObjectPoolingService<T>> where T : class
    {
        private List<ObjectPoolItem<T>> pooledItems = new List<ObjectPoolItem<T>>();

        public int amountToPool = 1;

        private void Start()
        {
            while (amountToPool != 0)
            {
                CreateNewPooledItem();
                amountToPool--;
            }
        }

        public virtual T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                ObjectPoolItem<T> item = pooledItems.Find(i => i.b_IsUsed == false);

                if (item != null)
                {
                    return item.item;
                }

                return CreateNewPooledItem();
            }

            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            ObjectPoolItem<T> pooledItem = new ObjectPoolItem<T>();
            pooledItem.item = CreateItem();
            pooledItem.b_IsUsed = true;
            pooledItems.Add(pooledItem);
            return pooledItem.item;
        }

        public virtual void ReturnItemToPool(T item)
        {
            ObjectPoolItem<T> pooledItem = pooledItems.Find(i => i.item.Equals(item));
            pooledItem.b_IsUsed = false;
        }

        protected virtual T CreateItem()
        {
            return (T)null;
        }

        protected virtual void RemoveAllPooledItems()
        {
            for (int i = 0; i < pooledItems.Count; i++)
            {
                pooledItems.Remove(pooledItems[i]);
            }
        }
    }
}
