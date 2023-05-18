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
    [SerializeField] private CanvasGroup _canvasGroup;

    private InventoryObjectPool _fruits;

    private void Awake()
    {
        _fruits = new InventoryObjectPool(_inventoryItemPrefab);
        _actions.InventoryActions.OnAddItemToInventory += AddFruit;
        _actions.InventoryActions.OnRemoveItemFromInventory += RemoveFruit;
        _actions.InventoryActions.OnCheckIfExist += CheckItemInInventory;
    }

    private void OnDisable()
    {
        _actions.InventoryActions.OnAddItemToInventory -= AddFruit;
        _actions.InventoryActions.OnRemoveItemFromInventory -= RemoveFruit;
        _actions.InventoryActions.OnCheckIfExist += CheckItemInInventory;
    }

    public void ShowInventory()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
    
    public void HideInventory()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
    
    private void AddFruit(Fruit fruit)
    {
        Debug.Log("SSSSSS");
        var inventoryItem = _fruits.GetObjectFromPool(_contentTransform);
        inventoryItem.InitializeItem(fruit.Name, fruit.FruitImage);
    }

    private void RemoveFruit(Fruit fruit)
    {
        _fruits.ReturnObjectToPool(fruit.Name);
    }

    private bool CheckItemInInventory(string fruitName)
    {
        var isExist = _fruits.CheckIfExist(fruitName);
        return isExist;
    }
    
}
