using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    // Info for Transform at https://docs.unity3d.com/ScriptReference/Transform.html
    private Transform scrollArea;
    private Transform scroll;
    private Transform container; // Gets the Transform for container
    private Transform shopItemTemplate; // Gets the Transform for shopItemTemplate

    public GameObject shopItemTemplateObject;

    private void Awake()
    {
        scrollArea = transform.Find("scrollArea"); // Grabs the refrences to our scrollArea
        scroll = scrollArea.Find("scroll"); // Inside our scrollArea is the refrence to the scroll
        container = scroll.Find("container"); // Inside our scroll is the refrence to the container
        shopItemTemplate = container.Find("shopItemTemplate"); // Inside our container is the refrence to the template
    }

    // Dynamically creates a new item in the shop
    private void Start()
    {
        CreateItemButton(Item.ItemType.bronzePogForPogs, Item.GetSprite(Item.ItemType.bronzePogForPogs), "Bronze Pog", Item.GetCost(Item.ItemType.bronzePogForPogs), GameAssets.i.pog, 0);
        CreateItemButton(Item.ItemType.silverPogForPogs, Item.GetSprite(Item.ItemType.silverPogForPogs), "Silver Pog", Item.GetCost(Item.ItemType.silverPogForPogs), GameAssets.i.pog, 1);
        CreateItemButton(Item.ItemType.silverPogForBronzePogs, Item.GetSprite(Item.ItemType.silverPogForBronzePogs), "Silver Pog", Item.GetCost(Item.ItemType.silverPogForBronzePogs), GameAssets.i.bronzePog, 2);
        CreateItemButton(Item.ItemType.goldPogForPogs, Item.GetSprite(Item.ItemType.goldPogForPogs), "Gold Pog", Item.GetCost(Item.ItemType.goldPogForPogs), GameAssets.i.pog, 3);
        CreateItemButton(Item.ItemType.goldPogForBronzePogs, Item.GetSprite(Item.ItemType.goldPogForBronzePogs), "Gold Pog", Item.GetCost(Item.ItemType.goldPogForBronzePogs), GameAssets.i.bronzePog, 4);
        CreateItemButton(Item.ItemType.goldPogForSilverPogs, Item.GetSprite(Item.ItemType.goldPogForSilverPogs), "Gold Pog", Item.GetCost(Item.ItemType.goldPogForSilverPogs), GameAssets.i.silverPog, 5);
        CreateItemButton(Item.ItemType.diamondPogForPogs, Item.GetSprite(Item.ItemType.diamondPogForPogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForPogs), GameAssets.i.pog, 6);
        CreateItemButton(Item.ItemType.diamondPogForBronzePogs, Item.GetSprite(Item.ItemType.diamondPogForBronzePogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForBronzePogs), GameAssets.i.bronzePog, 7);
        CreateItemButton(Item.ItemType.diamondPogForSilverPogs, Item.GetSprite(Item.ItemType.diamondPogForSilverPogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForSilverPogs), GameAssets.i.silverPog, 8);
        CreateItemButton(Item.ItemType.diamondPogForGoldPogs, Item.GetSprite(Item.ItemType.diamondPogForGoldPogs), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPogForGoldPogs), GameAssets.i.goldPog, 9);

        shopItemTemplateObject.SetActive(false);
    }

    // Spawns a template with a given name, sprite, and price
    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, Sprite currencySprite, int positionIndex)
    {
        // Duplicates the item template
        Transform shopItemTransform = Instantiate(shopItemTemplate, container); // Instantiate the item template inside the container
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>(); // Grabs the RectTransform of shopItemTransform (Info for RectTransform at https://docs.unity3d.com/ScriptReference/RectTransform.html)

        float shopItemHeight = 170f;
        // Modifies the anchored position by a certain item height multiplied by the index
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName); // Sets the item name
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString()); // Sets the cost text
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite; // Sets the item image
        shopItemTransform.Find("currencyImage").GetComponent<Image>().sprite = currencySprite; // Sets the currency image
    }
}
