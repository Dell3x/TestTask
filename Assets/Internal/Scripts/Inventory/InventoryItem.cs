using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _fruitName;
    [SerializeField] private Image _fruitImage;

    public void InitializeItem(string fruitName, Sprite fruitImage)
    {
        _fruitName.text = fruitName;
        _fruitImage.sprite = fruitImage;
    }
}
