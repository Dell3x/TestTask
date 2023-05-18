using System;
using UnityEngine;

namespace Game.Actions
{
    [CreateAssetMenu(fileName = "ShopActions", menuName = "Game/Actions/ShopActions")]
    public class ShopActions : ScriptableObject
    {
        public Action<int> OnSubsctractCurrency;
        public Action<int> OnAddCurrency;
        public Action<Fruit> OnBuyNewFruit;
        public Action<Fruit> OnSellFruit;

        public void RaiseSubstractCurrency(int currency)
        {
            OnSubsctractCurrency?.Invoke(currency);
        }

        public void RaiseBuyNewFruit(Fruit fruit)
        {
            OnBuyNewFruit?.Invoke(fruit);
        }

        public void RaiseAddCurrency(int currency)
        {
            OnAddCurrency?.Invoke(currency);
        }

        public void RaiseSellFruit(Fruit fruit)
        {
            OnSellFruit?.Invoke(fruit);
        }

    }
}