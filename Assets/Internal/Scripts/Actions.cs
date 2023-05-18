using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Actions
{
    [CreateAssetMenu(fileName = "Actions", menuName = "Game/Actions/Actions")]
    public class Actions : ScriptableObject
    {
        public ShopActions ShopActions;  
        public InventoryActions InventoryActions;

    }
}