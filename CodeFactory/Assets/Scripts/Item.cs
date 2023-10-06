using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Defines a bunch of item types
    public enum ItemType
    {
        // Buying System items
        bronzePogForPogs,
        silverPogForPogs,
        silverPogForBronzePogs,
        goldPogForPogs,
        goldPogForBronzePogs,
        goldPogForSilverPogs,
        diamondPogForPogs,
        diamondPogForBronzePogs,
        diamondPogForSilverPogs,
        diamondPogForGoldPogs,
        // Selling System items
        pogForStone,
        pogForCoal,
        pogForIron,
        pogsForGold,
        pogsForDiamond,
        bronzePogForDiamond
    }
    // Gets the items cost
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
                // Buying System items
                case ItemType.bronzePogForPogs:         return 10; // 1 Bronze Pog for 10 Pogs
                case ItemType.silverPogForPogs:         return 100; // 1 Silver Pog for 100 Pogs
                case ItemType.silverPogForBronzePogs:   return 10; // 1 Silver Pog for 10 Bronze Pogs
                case ItemType.goldPogForPogs:           return 1000; // 1 Gold Pog for 1000 Pogs
                case ItemType.goldPogForBronzePogs:     return 100; // 1 Gold Pog for 100 Bronze Pogs
                case ItemType.goldPogForSilverPogs:     return 10; // 1 Gold Pog for 10 Silver Pogs
                case ItemType.diamondPogForPogs:        return 10000; // 1 Diamond Pog for 10000 Pogs
                case ItemType.diamondPogForBronzePogs:  return 1000; // Diamond Pog for 1000 Bronze Pogs
                case ItemType.diamondPogForSilverPogs:  return 100; // Diamond Pog for 100 Silver Pogs
                case ItemType.diamondPogForGoldPogs:    return 10; // Diamond Pog for 10 Gold Pogs
                // Selling System items
                case ItemType.pogForStone:              return 10; // 1 Pog for 10 Stone
                case ItemType.pogForCoal:               return 5; // 1 Pog for 5 Coal
                case ItemType.pogForIron:               return 1; // 1 Pog for 1 Iron
                case ItemType.pogsForGold:              return 1; // 5 Pogs for 1 Gold
                case ItemType.pogsForDiamond:           return 1; // 10 Pogs for 1 Diamond
                case ItemType.bronzePogForDiamond:     return 1; // 1 Bronze Pog for 1 Diamond
        }
    }
    // Gets the items sprite
    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
                // Buying System sprites
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
                // Selling System sprites
                case ItemType.pogForStone:              return GameAssets.i.stone;
                case ItemType.pogForCoal:               return GameAssets.i.coal;
                case ItemType.pogForIron:               return GameAssets.i.iron;
                case ItemType.pogsForGold:              return GameAssets.i.gold;
                case ItemType.pogsForDiamond:           return GameAssets.i.diamond;
                case ItemType.bronzePogForDiamond:      return GameAssets.i.diamond;
        }
    }
}
