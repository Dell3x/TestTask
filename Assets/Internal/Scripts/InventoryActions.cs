using System;
using UnityEngine;

namespace Game.Actions
{
    [CreateAssetMenu(fileName = "InventoryActions", menuName = "Game/Actions/InventoryActions")]
    public class InventoryActions : ScriptableObject
    {
        public Action<Fruit> OnAddItemToInventory;
        public Action<Fruit> OnRemoveItemFromInventory;

        public void RaiseAddItemToInventory(Fruit fruit)
        {
            OnAddItemToInventory?.Invoke(fruit);
        }

        public void RaiseRemoveFromInventory(Fruit fruit)
        {
            OnRemoveItemFromInventory?.Invoke(fruit);
        }
    }
}