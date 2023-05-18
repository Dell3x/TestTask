using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Actions;
using Game.ObjectPool;
using UnityEngine;

public sealed class InventoryView : MonoBehaviour
{
    [SerializeField] private Actions _actions;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private InventoryItem _inventoryItemPrefab;

    private InventoryObjectPool<InventoryItem> _fruits;

    private void Awake()
    {
        _fruits = new InventoryObjectPool<InventoryItem>(_inventoryItemPrefab);
        _actions.InventoryActions.OnAddItemToInventory += AddFruit;
    }

    private void OnDisable()
    {
        _actions.InventoryActions.OnAddItemToInventory -= AddFruit;
    }

    private void AddFruit(Fruit fruit)
    {
        var inventoryItem = _fruits.GetObjectFromPool(_contentTransform);
        inventoryItem.InitializeItem(fruit.Name, fruit.FruitImage);
    }

    public void RemoveFruit(InventoryItem fruit)
    {
        _fruits.ReturnObjectToPool(fruit);
    }
}
