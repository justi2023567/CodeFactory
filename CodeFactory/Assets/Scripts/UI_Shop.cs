using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    // Info for Transform at https://docs.unity3d.com/ScriptReference/Transform.html
    private Transform container; // Gets the Transform for container
    private Transform shopItemTemplate; // Gets the Transform for shopItemTemplate
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container"); // Grabs the refrences to our container
        shopItemTemplate = container.Find("shopItemTemplate"); // Inside our container is the refrence to the template
    }

    // Dynamically creates a new item in the shop
    private void Start()
    {
        CreateItemButton(Item.ItemType.bronzePog, Item.GetSprite(Item.ItemType.bronzePog), "Bronze Pog", Item.GetCost(Item.ItemType.bronzePog), 0);
        CreateItemButton(Item.ItemType.silverPog, Item.GetSprite(Item.ItemType.silverPog), "Silver Pog", Item.GetCost(Item.ItemType.silverPog), 1);
        CreateItemButton(Item.ItemType.goldPog, Item.GetSprite(Item.ItemType.goldPog), "Gold Pog", Item.GetCost(Item.ItemType.goldPog), 2);
        CreateItemButton(Item.ItemType.diamondPog, Item.GetSprite(Item.ItemType.diamondPog), "Diamond Pog", Item.GetCost(Item.ItemType.diamondPog), 3);
    }

    // Spawns a template with a given name, sprite, and price
    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        // Duplicates the item template
        Transform shopItemTransform = Instantiate(shopItemTemplate, container); // Instantiate the item template inside the container
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>(); // Grabs the RectTransform of shopItemTransform (Info for RectTransform at https://docs.unity3d.com/ScriptReference/RectTransform.html)

        float shopItemHeight = 150f;
        // Modifies the anchored position by a certain item height multiplied by the index
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName); // Sets the item name
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString()); // Sets the cost text
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite; // Sets the item image
    }
}
