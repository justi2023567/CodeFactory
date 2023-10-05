using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    // Info for Transform at https://docs.unity3d.com/ScriptReference/Transform.html
    // Buying system transform objects
    private Transform buyingSystem; // Gets the Transform for buyingSystem
    private Transform scrollAreaBuy; // Gets the Transform for scrollArea
    private Transform scrollBuy; // Gets the Transform for scroll
    private Transform containerBuy; // Gets the Transform for container
    private Transform buyItemTemplate; // Gets the Transform for shopItemTemplate

    // Selling system transform objects
    private Transform sellingSystem; // Gets the Transform for buyingSystem
    private Transform scrollAreaSell; // Gets the Transform for scrollArea
    private Transform scrollSell; // Gets the Transform for scroll
    private Transform containerSell; // Gets the Transform for container
    private Transform sellItemTemplate; // Gets the Transform for shopItemTemplate


    // Creates a gameobject that holds both shop item templates
    public GameObject buyItemTemplateObject; // Buying system shopItemTemplate
    public GameObject sellItemTemplateObject; // Selling system shopItemTemplate

    private void Awake()
    {
        // Getting the refrences for the buying system
        buyingSystem = transform.Find("buyingSystem"); // Grabs the refrences to our buyingSystem
        scrollAreaBuy = buyingSystem.Find("scrollArea"); // Inside our buyingSystem is the refrence to the scrollArea
        scrollBuy = scrollAreaBuy.Find("scroll"); // Inside our scrollArea is the refrence to the scroll
        containerBuy = scrollBuy.Find("container"); // Inside our scroll is the refrence to the container
        buyItemTemplate = containerBuy.Find("shopItemTemplate"); // Inside our container is the refrence to the template

        // Getting the refrences for the selling system
        sellingSystem = transform.Find("sellingSystem"); // Grabs the refrences to our buyingSystem
        scrollAreaSell = sellingSystem.Find("scrollArea"); // Inside our buyingSystem is the refrence to the scrollArea
        scrollSell = scrollAreaSell.Find("scroll"); // Inside our scrollArea is the refrence to the scroll
        containerSell = scrollSell.Find("container"); // Inside our scroll is the refrence to the container
        sellItemTemplate = containerSell.Find("shopItemTemplate"); // Inside our container is the refrence to the template
    }

    private void Start()
    {
        // Dynamically creates a new item in the shop
        // Dynamic items for the buying system
        CreateItemButtonBuy(Item.ItemType.bronzePogForPogs, Item.GetSprite(Item.ItemType.bronzePogForPogs), "Bronze Pog", Item.GetCost(Item.ItemType.bronzePogForPogs), GameAssets.i.pog, 0);
        CreateItemButtonBuy(Item.ItemType.silverPogForPogs, Item.GetSprite(Item.ItemType.silverPogForPogs), "Silver Pog", Item.GetCost(Item.ItemType.silverPogForPogs), GameAssets.i.pog, 1);
        CreateItemButtonBuy(Item.ItemType.silverPogForBronzePogs, Item.GetSprite(Item.ItemType.silverPogForBronzePogs), "Silver Pog", Item.GetCost(Item.ItemType.silverPogForBronzePogs), GameAssets.i.bronzePog, 2);
        CreateItemButtonBuy(Item.ItemType.goldPogForPogs, Item.GetSprite(Item.ItemType.goldPogForPogs), "Gold Pog", Item.GetCost(Item.ItemType.goldPogForPogs), GameAssets.i.pog, 3);
        CreateItemButtonBuy(Item.ItemType.goldPogForBronzePogs, Item.GetSprite(Item.ItemType.goldPogForBronzePogs), "Gold Pog", Item.GetCost(Item.ItemType.goldPogForBronzePogs), GameAssets.i.bronzePog, 4);
        CreateItemButtonBuy(Item.ItemType.goldPogForSilverPogs, Item.GetSprite(Item.ItemType.goldPogForSilverPogs), "Gold Pog", Item.GetCost(Item.ItemType.goldPogForSilverPogs), GameAssets.i.silverPog, 5);
        CreateItemButtonBuy(Item.ItemType.diamondPogForPogs, Item.GetSprite(Item.ItemType.diamondPogForPogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForPogs), GameAssets.i.pog, 6);
        CreateItemButtonBuy(Item.ItemType.diamondPogForBronzePogs, Item.GetSprite(Item.ItemType.diamondPogForBronzePogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForBronzePogs), GameAssets.i.bronzePog, 7);
        CreateItemButtonBuy(Item.ItemType.diamondPogForSilverPogs, Item.GetSprite(Item.ItemType.diamondPogForSilverPogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForSilverPogs), GameAssets.i.silverPog, 8);
        CreateItemButtonBuy(Item.ItemType.diamondPogForGoldPogs, Item.GetSprite(Item.ItemType.diamondPogForGoldPogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForGoldPogs), GameAssets.i.goldPog, 9);
        // Dynamic items for the selling system
        CreateItemButtonSell(Item.ItemType.pogForStone, GameAssets.i.pog, "1 Pog", Item.GetCost(Item.ItemType.pogForStone), GameAssets.i.stone, 0);
        CreateItemButtonSell(Item.ItemType.pogForCoal, GameAssets.i.pog, "1 Pog", Item.GetCost(Item.ItemType.pogForCoal), GameAssets.i.stone, 1);
        CreateItemButtonSell(Item.ItemType.pogForIron, GameAssets.i.pog, "1 Pog", Item.GetCost(Item.ItemType.pogForIron), GameAssets.i.iron, 2);
        CreateItemButtonSell(Item.ItemType.pogsForGold, GameAssets.i.pog, "5 Pogs", Item.GetCost(Item.ItemType.pogsForGold), GameAssets.i.gold, 3);
        CreateItemButtonSell(Item.ItemType.pogsForDiamond, GameAssets.i.pog, "10 Pogs", Item.GetCost(Item.ItemType.pogsForDiamond), GameAssets.i.diamond, 4);
        CreateItemButtonSell(Item.ItemType.bronzePogForDiamond, GameAssets.i.bronzePog, "1 Bronze Pog", Item.GetCost(Item.ItemType.bronzePogForDiamond), GameAssets.i.diamond, 5);

        // Disables both shop item templates, leaving only the clones
        buyItemTemplateObject.SetActive(false);
        sellItemTemplateObject.SetActive(false);
    }

    // Spawns a template with a given item, sprite, name, price, currency sprite, and position index for the buying system
    private void CreateItemButtonBuy(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, Sprite currencySprite, int positionIndex)
    {
        // Duplicates the item template
        Transform shopItemTransform = Instantiate(buyItemTemplate, containerBuy); // Instantiate the item template inside the container

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName); // Sets the item name
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString()); // Sets the cost text
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite; // Sets the item image
        shopItemTransform.Find("currencyImage").GetComponent<Image>().sprite = currencySprite; // Sets the currency image
        shopItemTransform.gameObject.GetComponentInChildren<ShopUI_Button>().index = positionIndex; // Sets the position index
    }
    // Spawns a template with a given item, sprite, name, price, currency sprite, and position index for the selling system
    private void CreateItemButtonSell(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, Sprite sellingSprite, int positionIndex)
    {
        // Duplicates the item template
        Transform shopItemTransform = Instantiate(sellItemTemplate, containerSell); // Instantiate the item template inside the container

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName); // Sets the item name
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString()); // Sets the cost text
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite; // Sets the item image
        shopItemTransform.Find("sellingImage").GetComponent<Image>().sprite = sellingSprite; // Sets the selling image
        shopItemTransform.gameObject.GetComponentInChildren<ShopUI_Button>().index = positionIndex; // Sets the position index
    }
}
