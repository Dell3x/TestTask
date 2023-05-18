using UnityEngine;

public sealed class ShopView : MonoBehaviour
{
    [SerializeField] private ShopData _availableFruits;
    [SerializeField] private FruitShopItem fruitShopItem;
    [SerializeField] private Transform _fruitsContent;
    [SerializeField] private bool _isBuyShop;

    private void Start()
    {
        InitializeAvailableFruits();
    }

    private void InitializeAvailableFruits()
    {
        foreach (var fruit in _availableFruits._fruitsList)
        {
            var fruitItem = Instantiate(fruitShopItem, _fruitsContent);
            fruitItem.initializeItem(fruit.Name, fruit.Price, fruit.FruitImage, _isBuyShop);
        }
    }

}
