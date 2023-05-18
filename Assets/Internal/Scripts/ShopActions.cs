using System;
using UnityEngine;

namespace Game.Actions
{
    [CreateAssetMenu(fileName = "ShopActions", menuName = "Game/Actions/ShopActions")]
    public class ShopActions : ScriptableObject
    {
        public Action<int> OnSubsctractCurrency;
        public Action<Fruit> OnBuyNewFruit;

        public void RaiseSubstractCurrency(int currency)
        {
            OnSubsctractCurrency?.Invoke(currency);
        }

        public void RaiseBuyNewFruit(Fruit fruit)
        {
            OnBuyNewFruit?.Invoke(fruit);
        }

    }
}