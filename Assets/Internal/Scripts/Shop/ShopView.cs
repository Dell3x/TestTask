using UnityEngine;

public sealed class ShopView : MonoBehaviour
{
    [SerializeField] private ShopData _availableFruits;
    [SerializeField] private FruitItem _fruitItem;
    [SerializeField] private Transform _fruitsContent;

    private void Start()
    {
        InitializeAvailableFruits();
    }

    private void InitializeAvailableFruits()
    {
        foreach (var fruit in _availableFruits._fruitsList)
        {
            var fruitItem = Instantiate(_fruitItem, _fruitsContent);
            fruitItem.initializeItem(fruit.Name, fruit.Price, fruit.FruitImage);
        }
    }

}
