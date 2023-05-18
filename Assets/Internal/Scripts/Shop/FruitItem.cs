using Game.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitItem : MonoBehaviour
{
    [SerializeField] private Actions _actions;
    [SerializeField] private TMP_Text _fruitName;
    [SerializeField] private TMP_Text _fruitCost;
    [SerializeField] private Image _fruitImage;
    [SerializeField] private Button _buyButton;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        var fruit = new Fruit();
        fruit.Name = _fruitName.text;
        fruit.Price = int.Parse(_fruitCost.text);
        fruit.FruitImage = _fruitImage.sprite;
        _actions.ShopActions.RaiseBuyNewFruit(fruit);
    }

    public void initializeItem(string FruitName, int fruitPrice, Sprite fruitImage)
    {
        _fruitName.text = FruitName;
        _fruitCost.text = $"{fruitPrice}";
        _fruitImage.sprite = fruitImage;
    }
}
