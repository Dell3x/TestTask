using System;
using TMPro;
using UnityEngine;

namespace Game.Managers
{
    public class CurrencyManager : MonoBehaviour
    {
        [SerializeField] private Actions.Actions _actions;
        [SerializeField] private TMP_Text _currencyText;
        private int _currencyAmount;

        private void Awake()
        {
            _actions.ShopActions.OnSubsctractCurrency += SubtractCurrency;
            _actions.ShopActions.OnAddCurrency += UpdateCurrencyAmount;
            InitializeStartCurrency();
        }

        private void OnDisable()
        {
            _actions.ShopActions.OnSubsctractCurrency -= SubtractCurrency;
            _actions.ShopActions.OnAddCurrency -= UpdateCurrencyAmount;
        }

        private void AddCurrency(int amount)
        {
            _currencyAmount += amount;
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

        private void UpdateCurrencyAmount(int currency)
        {
            _currencyAmount += currency;
            UpdateCurrencyText();
        }
    }
}