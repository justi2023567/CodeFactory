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

    private void Awake()
    {
        container = transform.Find("container"); // Grabs the refrences to our container
        shopItemTemplate = container.Find("shopItemTemplate"); // Inside our container is the refrence to the template
        shopItemTemplate.gameObject.SetActive(false); // Starts with the template hidden
    }

    private void Start()
    {
        
    }

    // Spawns a template with a given name, sprite, and price
    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        // Duplicates the item template
        Transform shopItemTransform = Instantiate(shopItemTemplate, container); // Instantiate the item template inside the container
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>(); // Grabs the RectTransform of shopItemTransform (Info for RectTransform at https://docs.unity3d.com/ScriptReference/RectTransform.html)

        float shopItemHeight = 30f;
        // Modifies the anchored position by a certain item height multiplied by the index
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName); // Sets the item name
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString()); // Sets the cost text

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite; // Sets the item image
    }
}
