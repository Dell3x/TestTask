using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Data", menuName = "Game/Data/ShopData")]
public class ShopData : ScriptableObject
{
    public List<Fruit> _fruitsList;
}
    