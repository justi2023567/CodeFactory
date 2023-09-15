using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Defines a bunch of item types
    public enum ItemType
    {
        bronzePog,
        silverPog,
        goldPog,
        diamondPog
    }
    // Gets the items cost
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
                case ItemType.bronzePog:    return 10;
                case ItemType.silverPog:    return 100;
                case ItemType.goldPog:      return 1000;
                case ItemType.diamondPog:   return 10000;
        }
    }
    // Gets the items sprite
    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
                case ItemType.bronzePog:    return GameAssets.i.bronzePog;
                case ItemType.silverPog:    return GameAssets.i.silverPog;
                case ItemType.goldPog:      return GameAssets.i.goldPog;
                case ItemType.diamondPog:   return GameAssets.i.diamondPog;
        }
    }
}
