using Game.GameActions;
using Game.ObjectPool;
using UnityEngine;

public sealed class InventoryView : MonoBehaviour
{
    [SerializeField] private Actions _actions;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private InventoryItem _inventoryItemPrefab;
    [SerializeField] private CanvasGroup _canvasGroup;

    private InventoryObjectPool _fruitsPool;

    private void Awake()
    {
        _fruitsPool = new InventoryObjectPool(_inventoryItemPrefab);
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
        var inventoryItem = _fruitsPool.GetObjectFromPool(_contentTransform);
        inventoryItem.InitializeItem(fruit.Name, fruit.FruitImage);
    }

    private void RemoveFruit(Fruit fruit)
    {
        _fruitsPool.ReturnObjectToPool(fruit.Name);
    }

    private bool CheckItemInInventory(string fruitName)
    {
        var isFruitExist = _fruitsPool.CheckIfExist(fruitName);
        return isFruitExist;
    }
}
