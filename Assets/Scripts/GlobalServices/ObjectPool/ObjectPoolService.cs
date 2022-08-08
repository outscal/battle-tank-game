using System.Collections.Generic;

namespace GlobalServices
{
    [System.Serializable]
    // Generic class to store object of type T and it's current state.
    public class ObjectPoolItem<T>
    {
        public T item;
        public bool b_IsUsed;
    }

    // Template for creating object pool class. // Generic object pool class.
    public class ObjectPoolService<T> : MonoSingletonGeneric<ObjectPoolService<T>> where T : class
    {
        // List of objects of particular type stored in object pool.
        private List<ObjectPoolItem<T>> pooledItems = new List<ObjectPoolItem<T>>();

        // Minimum objects in the pool.
        public int amountToPool = 1;

        private void Start()
        {
            // Creates required pool of objects at the begining of game.
            while(amountToPool != 0)
            {
                CreateNewPooledItem();
                amountToPool--;
            }
        }

        // Returns un-used object from the pool.
        public virtual T GetItem()
        {
            if(pooledItems.Count > 0)
            {
                // To search un-used object in the pool.
                ObjectPoolItem<T> item = pooledItems.Find(i => i.b_IsUsed == false);
                
                // If object found.
                if(item != null)
                {
                    return item.item;
                }
                
                // Else create new object in the pool and return it.
                return CreateNewPooledItem();
            }

            // If pool count is zero create new object in the pool.
            return CreateNewPooledItem();
        }

        // To create new object and add to the object pool. Returns newly created object.
        private T CreateNewPooledItem()
        {
            ObjectPoolItem<T> pooledItem = new ObjectPoolItem<T>();
            pooledItem.item = CreateItem();
            pooledItem.b_IsUsed = true;
            pooledItems.Add(pooledItem);
            return pooledItem.item;
        }

        // To return object back to pool. // We change it's state to un-used object.
        public virtual void ReturnItemToPool(T item)
        {
            ObjectPoolItem<T> pooledItem = pooledItems.Find(i => i.item.Equals(item));
            pooledItem.b_IsUsed = false;
        }

        // The function has to be implemented by inheriting classes.
        protected virtual T CreateItem()
        {
            return (T)null;
        }

        // Removes all objects from the pool.
        protected virtual void RemoveAllPooledItems()
        {
            for(int i=0; i<pooledItems.Count; i++)
            {
                pooledItems.Remove(pooledItems[i]);
            }
        }
    }
}
