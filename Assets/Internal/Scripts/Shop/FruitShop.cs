using Game.Controllers;
using Game.GameActions;
using Game.Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Shop
{
    public class FruitShop : MonoBehaviour
    {
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private Actions _actions;
        [SerializeField] private GameObject _fruitPurchaseMenu;
        [SerializeField] private Button _shopButton;

        private void Awake()
        {
            _actions.ShopActions.OnBuyNewFruit += BuyFruit;
        }

        private void OnDisable()
        {
            _actions.ShopActions.OnBuyNewFruit -= BuyFruit;
        }
        
        public void OpenFruitPurchaseMenu()
        {
            _fruitPurchaseMenu.SetActive(true);
        }
        
        public void CloseFruitPurchaseMenu()
        {
            _fruitPurchaseMenu.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<UnitMovement>(out var unit))
            {
                ShowShopButton();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<UnitMovement>(out var unit))
            {
                HideShopButton();
                CloseFruitPurchaseMenu();
            }
        }

        private void ShowShopButton()
        {
            _shopButton.gameObject.SetActive(true);
        }

        private void HideShopButton()
        {
            _shopButton.gameObject.SetActive(false);
        }

        private void BuyFruit(Fruit fruit)
        {
            if (_currencyController.IsEnoughMoney(fruit.Price))
            {
                _actions.ShopActions.RaiseSubstractCurrency(fruit.Price);
                _actions.InventoryActions.RaiseAddItemToInventory(fruit);
            }
            else
            {
                Debug.Log("Not enough currency to buy this fruit!");
            }
        }
    }
}