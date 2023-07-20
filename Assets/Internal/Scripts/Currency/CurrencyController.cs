using TMPro;
using UnityEngine;
using Game.GameActions;

namespace Game.Controllers
{
    public class CurrencyController : MonoBehaviour
    {
        [SerializeField] private Actions _actions;
        [SerializeField] private TMP_Text _currencyText;
        
        private int _currencyAmount;

        private void Awake()
        {
            _actions.ShopActions.OnSubsctractCurrency += SubtractCurrency;
            _actions.ShopActions.OnAddCurrency += AddCurrency;
            InitializeStartCurrency();
        }

        private void OnDisable()
        {
            _actions.ShopActions.OnSubsctractCurrency -= SubtractCurrency;
            _actions.ShopActions.OnAddCurrency -= AddCurrency;
        }

        private void AddCurrency(int currency)
        {
            _currencyAmount += currency;
            UpdateCurrencyText();
        }

        private void SubtractCurrency(int amount)
        {
            _currencyAmount -= amount;
            UpdateCurrencyText();
        }

        public bool IsEnoughMoney(int price)
        {
            if (_currencyAmount >= price)
            {
                return true;
            }

            return false;
        }

        private void InitializeStartCurrency()
        {
            _currencyAmount = 100;
            UpdateCurrencyText();
        }

        private void UpdateCurrencyText()
        {
            _currencyText.text = $"{_currencyAmount}";
        }
    }
}