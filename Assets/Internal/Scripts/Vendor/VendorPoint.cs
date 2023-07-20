using System;
using Game.GameActions;
using Game.Unit;
using UnityEngine;
using UnityEngine.UI;

public class VendorPoint : MonoBehaviour
{
    [SerializeField] private Actions _actions;
    [SerializeField] private GameObject _fruitSellMenu;
    [SerializeField] private Button _sellButton;

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
            ShowVendorButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<UnitMovement>(out UnitMovement unit))
        {
            HideVendorButton();
            CloseFruitSellMenu();
        }
    }

    public void OpenFruitSellMenu()
    {
        _fruitSellMenu.SetActive(true);
    }
    
    private void ShowVendorButton()
    {
        _sellButton.gameObject.SetActive(true);
    }

    private void HideVendorButton()
    {
        _sellButton.gameObject.SetActive(false);
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
