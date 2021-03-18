using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    private readonly static Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();

    /// <summary>
    /// Linked List node associated with each GameObject Instances
    /// </summary>
    private readonly static Dictionary<GameObject, KeyValuePair<Pool, LinkedListNode<GameObject>>> nodes = new Dictionary<GameObject, KeyValuePair<Pool, LinkedListNode<GameObject>>>();

    public static int globalPoolSize = 20;
    public static int globalNetPoolSize = 30;

    /// <summary>
    /// Instantiate a gameobject into the pool transform and other stuff needs to be set via script
    /// </summary>
    /// <param name="prefab">The Copy of the gameObject which needs to be instantiated</param>
    /// <returns>The instance of the prefab or copy which was instantiated</returns>
    public static GameObject Instantiate(GameObject prefab)
    {
        Pool t;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, t = new Pool());

        }
        else
        {
            t = pools[prefab];
        }

        LinkedListNode<GameObject> node = t.InsertToPool(prefab);
        if (!nodes.ContainsKey(node.Value))
            nodes.Add(node.Value, new KeyValuePair<Pool, LinkedListNode<GameObject>>(t, node));
        return node.Value;
    }

    public static void InitializePool(GameObject prefab, int count, bool dontDestroyOnLoad)
    {
        GetPool(prefab).FillPool(prefab, count, dontDestroyOnLoad);
    }


    #region Instantiate Overloads

    public static GameObject Instantiate(GameObject prefab, Transform parent)
    {
        GameObject obj = Instantiate(prefab);

        obj.transform.parent = parent;
        return obj;
    }


    public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj = Instantiate(prefab);

        obj.transform.position = position;
        obj.transform.rotation = rotation;

        return obj;
    }
    public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.parent = parent;
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    public static GameObject Instantiate(GameObject prefab, Transform parent, bool instantiateInWorldSpace)
    {
        GameObject obj = Instantiate(prefab);

        obj.transform.parent = parent;
        obj.transform.position = parent.transform.position;
        obj.transform.rotation = parent.transform.rotation;
        obj.transform.localScale = Vector3.one;
        return obj;
    }

    #endregion




    public static Pool CreatePool(GameObject prefab, int poolSize)
    {
        Pool newPool;
        if (pools.ContainsKey(prefab))
        {
            newPool = pools[prefab];
        }
        else
        {
            newPool = new Pool();
            pools.Add(prefab, newPool);
        }
        newPool.poolSize = Mathf.Max(poolSize, newPool.poolSize);
        return newPool;
    }

    /// <summary>
    /// Gives access to object pool of the prefab
    /// </summary>
    public static Pool GetPool(GameObject prefab)
    {
        if (pools.ContainsKey(prefab))
            return pools[prefab];
        Pool t;
        pools.Add(prefab, t = new Pool());
        return t;
    }

    /// <param name="poolSize">Size of the object pool of this prefab.</param>
    public static GameObject Instantiate(GameObject prefab, int poolSize)
    {
        Pool t;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, t = new Pool());

        }
        else
        {
            t = pools[prefab];
        }
        t.poolSize = poolSize;
        return Instantiate(prefab);
    }


    /// <summary>
    /// Instantiate the object ignoring the pool limit it follows pool actions afterwards.
    /// </summary>
    public static GameObject InstantiateGrowing(GameObject prefab)
    {
        GameObject obj;
        Pool t;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, t = new Pool());
        }
        else
        {
            t = pools[prefab];
        }
        if (t.growing != true)
        {
            t.growing = true;
            obj = Instantiate(prefab);
            t.growing = false;
        }
        else
            obj = Instantiate(prefab);
        return obj;
    }


    /// <summary>
    /// Sets the number of active objects in the pool for the prefab at any given time
    /// </summary>
    public static void SetPoolSize(GameObject prefab, int size)
    {
        Pool t;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, t = new Pool());
        }
        else
        {
            t = pools[prefab];
        }
        t.poolSize = size;
    }

    /// <summary>
    /// Sets the total number of objects in the pool for the prefab at any given time including booth active and inactive
    /// </summary>
    public static void SetNetPoolSize(GameObject prefab, int size)
    {
        Pool t;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, t = new Pool());
        }
        else
        {
            t = pools[prefab];
        }
        t.netPoolSize = size;
    }

    public static void RemoveObjectFromPool(GameObject obj)
    {
        if (nodes.ContainsKey(obj))
        {
            nodes[obj].Key.RemoveObjectFromPool(nodes[obj].Value);
            nodes.Remove(obj);
        }
    }



    /// <summary>
    /// Destroy a pool Object.(Sets it inactive until another pool object is to be instantiated).If not in pool it is destroyed normally.
    /// </summary>
    public static void Destroy(GameObject obj)
    {
        if (nodes.ContainsKey(obj))
        {
            Pool pool = nodes[obj].Key;
            LinkedListNode<GameObject> node = nodes[obj].Value;

            if (pool.totalCount > pool.netPoolSize && !pool.growing)
            {
                pool.RemoveObjectFromPool(node);
                Object.Destroy(obj);
            }
            else
            {
                pool.Destroy(node);
            }
        }
        else
            Object.Destroy(obj);
    }

    public class Pool
    {
        /// <summary>
        /// If set true the pool will not forcefully recycle gameObjects if pool is full
        /// </summary>
        public bool growing = true;
        public bool persistent = false;
        public int poolSize = 10;
        public int netPoolSize = 30;

        public int activeCount
        {
            get { return activeObjects.Count; }
        }

        public int totalCount
        {
            get { return activeObjects.Count + inactiveObjects.Count; }
        }

        /// <summary>
        /// Linked list corresponding to the active gameObjects in the pool
        /// </summary>
        public LinkedList<GameObject> activeObjects = new LinkedList<GameObject>();
        /// <summary>
        /// Linked list corresponding to the objects which have been "Destroyed" and is waiting in pool to be reused
        /// </summary>
        public LinkedList<GameObject> inactiveObjects = new LinkedList<GameObject>();


        public Pool()
        {
            poolSize = globalPoolSize;
            netPoolSize = Mathf.Max(globalNetPoolSize, globalPoolSize);
        }

        public Pool(int poolSize)
        {
            this.poolSize = poolSize;
        }


        public void FillPool(GameObject gameObject, int count, bool dontDestroyOnLoad)
        {
            if (dontDestroyOnLoad)
                persistent = true;
            count = count - inactiveObjects.Count;
            for (int i = 0; i < count; i++)
            {
                inactiveObjects.AddLast(new LinkedListNode<GameObject>(Object.Instantiate(gameObject)));
                if (dontDestroyOnLoad)
                    Object.DontDestroyOnLoad(inactiveObjects.Last.Value);
                inactiveObjects.Last.Value.SetActive(false);
            }
        }

        public LinkedListNode<GameObject> InsertToPool(GameObject gameObject)
        {
            LinkedListNode<GameObject> node;
            if (!growing)
            {
                if (activeCount >= poolSize)
                    Destroy();
            }

            if (inactiveObjects.Count > 0)
            {
                node = inactiveObjects.First;
                inactiveObjects.Remove(node);
                activeObjects.AddLast(node);
                node.Value.SetActive(true);
            }
            else
            {
                node = new LinkedListNode<GameObject>(Object.Instantiate(gameObject));
                activeObjects.AddLast(node);
            }
            if (persistent)
                Object.DontDestroyOnLoad(node.Value);
            return node;
        }
        public void DestroyAll()
        {
            while (activeObjects.Count > 0)
                Destroy();
        }
        public void Destroy()
        {
            if (activeObjects.Count > 0)
            {
                activeObjects.First.Value.SetActive(false);
                LinkedListNode<GameObject> node = activeObjects.First;
                activeObjects.Remove(node);
                inactiveObjects.AddLast(node);
            }
        }
        public void Destroy(LinkedListNode<GameObject> node)
        {
            node.Value.SetActive(false);

            if (node.List == inactiveObjects)
            {
                return;
            }
            activeObjects.Remove(node);

            inactiveObjects.AddLast(node);

        }

        /// <summary>
        /// Removes the node from the respective list and hence pool
        /// </summary>
        public void RemoveObjectFromPool(LinkedListNode<GameObject> node)
        {
            if (node.List == activeObjects)
            {
                activeObjects.Remove(node);
            }
            else if (node.List == inactiveObjects)
            {
                inactiveObjects.Remove(node);
            }
        }


        /// <summary>
        /// Destroys all inactive GameObjects in the pool with Object.Destroy be careful when using this.
        /// </summary>
        public void ClearInactive()
        {
            while (inactiveObjects.Count != 0)
            {
                GameObject obj = inactiveObjects.First.Value;
                nodes.Remove(obj);
                inactiveObjects.RemoveFirst();
                Object.Destroy(obj);
            }
        }
    }
}