using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShopItemBuffType
{
    Firerate, 
    Damage, 
    Money, 
    Health, 
    Piercing, 
    Explosion, 
    Arrows, 
}

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int cost;
    public bool isPermanent;
    public float duration;
    public ShopItemBuffType buffType;
    public float buffAmount;
}
