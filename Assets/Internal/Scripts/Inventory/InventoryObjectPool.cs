using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.ObjectPool
{
    public sealed class InventoryObjectPool
    {
        private List<InventoryItem> _pool;
        private readonly InventoryItem _inventoryPrefab;

        public InventoryObjectPool(InventoryItem inventoryPrefab)
        {
            _inventoryPrefab = inventoryPrefab;
            _pool = new List<InventoryItem>();
        }

        public InventoryItem GetObjectFromPool(Transform parentTransform = null)
        {
            if (_pool != null)
            {
                foreach (InventoryItem obj in _pool)
                {
                    if (!obj.gameObject.activeInHierarchy)
                    {
                        obj.gameObject.SetActive(true);
                        return obj;
                    }
                }
            }

            var newObject = Object.Instantiate(_inventoryPrefab, parentTransform);
            _pool.Add(newObject);
            return newObject;
        }

        public void ReturnObjectToPool(string fruitName)
        {
            var inventoryItem = _pool.FirstOrDefault(i => i.FruitName.text == fruitName && i.gameObject.activeInHierarchy);
            if (inventoryItem != null)
            {
                inventoryItem.gameObject.SetActive(false);
            }
        }

        public bool CheckIfExist(string fruitName)
        {
            return _pool.Any(item => item.FruitName.text == fruitName && item.gameObject.activeSelf);
        }
    }
}