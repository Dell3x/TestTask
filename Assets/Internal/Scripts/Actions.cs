using UnityEngine;

namespace Game.GameActions
{
    [CreateAssetMenu(fileName = "Actions", menuName = "Game/Actions/Actions")]
    public class Actions : ScriptableObject
    {
        public ShopActions ShopActions;  
        public InventoryActions InventoryActions;
    }
}