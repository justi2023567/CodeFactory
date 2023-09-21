using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Defines a bunch of item types
    public enum ItemType
    {
        bronzePogForPogs,
        silverPogForPogs,
        silverPogForBronzePogs,
        goldPogForPogs,
        goldPogForBronzePogs,
        goldPogForSilverPogs,
        diamondPogForPogs,
        diamondPogForBronzePogs,
        diamondPogForSilverPogs,
        diamondPogForGoldPogs
    }
    // Gets the items cost
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
                case ItemType.bronzePogForPogs:         return 10;
                case ItemType.silverPogForPogs:         return 100;
                case ItemType.silverPogForBronzePogs:   return 10;
                case ItemType.goldPogForPogs:           return 1000;
                case ItemType.goldPogForBronzePogs:     return 100;
                case ItemType.goldPogForSilverPogs:     return 10;
                case ItemType.diamondPogForPogs:        return 10000;
                case ItemType.diamondPogForBronzePogs:  return 1000;
                case ItemType.diamondPogForSilverPogs:  return 100;
                case ItemType.diamondPogForGoldPogs:    return 10;
        }
    }
    // Gets the items sprite
    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
                case ItemType.bronzePogForPogs:         return GameAssets.i.bronzePog;
                case ItemType.silverPogForPogs:         return GameAssets.i.silverPog;
                case ItemType.silverPogForBronzePogs:   return GameAssets.i.silverPog;
                case ItemType.goldPogForPogs:           return GameAssets.i.goldPog;
                case ItemType.goldPogForBronzePogs:     return GameAssets.i.goldPog;
                case ItemType.goldPogForSilverPogs:     return GameAssets.i.goldPog;
                case ItemType.diamondPogForPogs:        return GameAssets.i.diamondPog;
                case ItemType.diamondPogForBronzePogs:  return GameAssets.i.diamondPog;
                case ItemType.diamondPogForSilverPogs:  return GameAssets.i.diamondPog;
                case ItemType.diamondPogForGoldPogs:    return GameAssets.i.diamondPog;
        }
    }
}
