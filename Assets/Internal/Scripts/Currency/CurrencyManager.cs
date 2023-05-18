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
            InitializeStartCurrency();
        }

        private void OnDisable()
        {
            _actions.ShopActions.OnSubsctractCurrency -= SubtractCurrency;
        }

        private void AddCurrency(int amount)
        {
            _currencyAmount += amount;
            UpdateCurrency();
        }

        private void SubtractCurrency(int amount)
        {
            _currencyAmount -= amount;
            UpdateCurrency();
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
            UpdateCurrency();
        }

        private void UpdateCurrency()
        {
            _currencyText.text = $"{_currencyAmount}";
        }
    }
}