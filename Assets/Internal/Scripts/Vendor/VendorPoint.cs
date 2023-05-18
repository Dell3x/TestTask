using Game.Actions;
using Game.Unit;
using UnityEngine;
public class VendorPoint : MonoBehaviour
{
    [SerializeField] private Actions _actions;
    [SerializeField] private GameObject _fruitSellMenu;

    private void Awake()
    {
        _actions.ShopActions.OnSellFruit += SellFruit;
    }

    private void OnDisable()
    {
        _actions.ShopActions.OnSellFruit -= SellFruit;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<UnitMovement>(out UnitMovement unit))
        {
            OpenFruitSellMenu();
        }
    }
    private void OpenFruitSellMenu()
    {
        _fruitSellMenu.SetActive(true);
    }

    private void SellFruit(Fruit fruit)
    {
       var IsExistInInventory = _actions.InventoryActions.RaiseCheckIfExist(fruit.Name);
       if (IsExistInInventory)
       {
           _actions.ShopActions.RaiseAddCurrency(fruit.Price);
           _actions.InventoryActions.RaiseRemoveFromInventory(fruit);
       }
       else
       {
           Debug.Log("The item is not in the inventory!");
       }
    }
    
    public void CloseFruitSellMenu()
    {
        _fruitSellMenu.SetActive(false);
    }
}