using Game.GameActions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitShopItem : MonoBehaviour
{
    [SerializeField] private Actions _actions;
    [SerializeField] private TMP_Text _fruitName;
    [SerializeField] private TMP_Text _fruitCost;
    [SerializeField] private Image _fruitImage;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private bool _isShopItem;

    private void OnEnable()
    {
        if (_isShopItem)
        {
            _buyButton.gameObject.SetActive(true);
            _buyButton.onClick.AddListener(OnBuyButtonClicked);
        }
        else
        {
            _sellButton.gameObject.SetActive(true);
            _sellButton.onClick.AddListener(OnSellButtonClicked);
        }
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveAllListeners();
        _sellButton.onClick.RemoveAllListeners();
    }

    private void OnBuyButtonClicked()
    {
        var fruit = new Fruit();
        fruit.Name = _fruitName.text;
        fruit.Price = int.Parse(_fruitCost.text);
        fruit.FruitImage = _fruitImage.sprite;
        _actions.ShopActions.RaiseBuyNewFruit(fruit);
    }

    private void OnSellButtonClicked()
    {
        var fruit = new Fruit();
        fruit.Name = _fruitName.text;
        fruit.Price = int.Parse(_fruitCost.text);
        fruit.FruitImage = _fruitImage.sprite;
        _actions.ShopActions.RaiseSellFruit(fruit);
    }

    public void initializeItem(string FruitName, int fruitPrice, Sprite fruitImage, bool isShopItem)
    {
        _fruitName.text = FruitName;
        _isShopItem = isShopItem;
        if (_isShopItem)
        {
            _fruitCost.text = $"{fruitPrice}";
        }
        else
        {
            _fruitCost.text = $"{fruitPrice + 5}";
        }
        _fruitImage.sprite = fruitImage;
    }
}
