using System.Collections.Generic;
using UnityEngine;

namespace Game.ObjectPool
{
    public class InventoryObjectPool<T> where T : MonoBehaviour
    {
        private readonly List<T> pool;
        private readonly T prefab;
        
        public InventoryObjectPool(T prefab)
        {
            this.prefab = prefab;
            pool = new List<T>();
        }

        public T GetObjectFromPool(Transform parentTransform)
        {
            if (pool != null)
            {
                foreach (T obj in pool)
                {
                    if (!obj.gameObject.activeInHierarchy)
                    {
                        obj.gameObject.SetActive(true);
                        return obj;
                    }
                }
            }

            var newObject = Object.Instantiate(prefab, parentTransform);
            pool.Add(newObject);
            return newObject;
        }

        public void ReturnObjectToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}