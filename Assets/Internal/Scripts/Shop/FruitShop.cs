using System;
using System.Collections.Generic;
using Game.Managers;
using Game.Unit;
using UnityEngine;

namespace Game.Shop
{
    public class FruitShop : MonoBehaviour
    {
        [SerializeField] private CurrencyManager currencyManager;
        [SerializeField] private Actions.Actions _actions;
        [SerializeField] private GameObject fruitPurchaseMenu;

        private void Awake()
        {
            _actions.ShopActions.OnBuyNewFruit += BuyFruit;
        }

        private void OnDisable()
        {
            _actions.ShopActions.OnBuyNewFruit -= BuyFruit;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<UnitMovement>(out UnitMovement unit))
            {
                OpenFruitPurchaseMenu();
            }
        }

        private void OpenFruitPurchaseMenu()
        {
            fruitPurchaseMenu.SetActive(true);
        }

        private void BuyFruit(Fruit fruit)
        {
            if (currencyManager.IsEnoughMoney(fruit.Price))
            {
                _actions.ShopActions.RaiseSubstractCurrency(fruit.Price);
                _actions.InventoryActions.RaiseAddItemToInventory(fruit);
                
            }
            else
            {
                Debug.Log("Not enough currency to buy this fruit!");
            }
        }

        public void CloseFruitPurchaseMenu()
        {
            fruitPurchaseMenu.SetActive(false);
        }
    }
}