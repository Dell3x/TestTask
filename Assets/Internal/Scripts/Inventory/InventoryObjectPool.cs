using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.ObjectPool
{
    public class InventoryObjectPool : MonoBehaviour
    {
        private List<InventoryItem> pool;
        private readonly InventoryItem prefab;

        public InventoryObjectPool(InventoryItem prefab)
        {
            this.prefab = prefab;
            pool = new List<InventoryItem>();
        }

        public InventoryItem GetObjectFromPool(Transform parentTransform = null)
        {
            if (pool != null)
            {
                foreach (InventoryItem obj in pool)
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

        public void ReturnObjectToPool(string fruitName)
        {
            var inventoryItem = pool.FirstOrDefault(i => i.FruitName.text == fruitName);
            if (inventoryItem != null)
            {
                pool.Remove(inventoryItem);
                inventoryItem.gameObject.SetActive(false);
            }
        }

        public bool CheckIfExist(string fruitName)
        {
            return pool.Any(item => item.FruitName.text == fruitName && item.gameObject.activeSelf);
        }
    }
}