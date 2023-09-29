using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI_Button : MonoBehaviour
{
    // Used to know which item (button) is being clicked (same as the position index from the UI_Shop.cs script)
    public int index;

    // Holds the inventory
    public Inventory script;

    // Creates a gameobject for the text thats going to change
    public GameObject changingText;

    // Function used to check if the button was clicked
    public void buttonClicked()
    {
        // Checks if the index is the same as the index that you clicked and if you have enough of the currency to buy the item
        if (index == 0 && script.pogCount >= 10)
        {
            script.bronzePogCount++;
            script.pogCount -= 10;
            return;
        }
        if (index == 1 && script.pogCount >= 100)
        {
            script.silverPogCount++;
            script.pogCount -= 100;
            return;
        }
        if (index == 2 && script.bronzePogCount >= 10)
        {
            script.silverPogCount++;
            script.bronzePogCount -= 10;
            return;
        }
        if (index == 3 && script.pogCount >= 1000)
        {
            script.goldPogCount++;
            script.pogCount -= 1000;
            return;
        }
        if (index == 4 && script.bronzePogCount >= 100)
        {
            script.goldPogCount++;
            script.bronzePogCount -= 100;
            return;
        }
        if (index == 5 && script.silverPogCount >= 10)
        {
            script.goldPogCount++;
            script.silverPogCount -= 10;
            return;
        }
        if (index == 6 && script.pogCount >= 10000)
        {
            script.diamondPogCount++;
            script.pogCount -= 10000;
            return;
        }
        if (index == 7 && script.bronzePogCount >= 1000)
        {
            script.diamondPogCount++;
            script.bronzePogCount -= 1000;
            return;
        }
        if (index == 8 && script.silverPogCount >= 100)
        {
            script.diamondPogCount++;
            script.silverPogCount -= 100;
            return;
        }
        if (index == 9 && script.goldPogCount >= 10)
        {
            script.diamondPogCount++;
            script.goldPogCount -= 10;
            return;
        }
    }

    // Function used to check if the mouse is hovering on top of the item
    public void onHover()
    {
        // If the index is the same as the index you are hovering over, the description gets changed to the description of that item
        if (index == 0)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Bronze Pog.";
            return;
        }
        else if (index == 1)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Silver Pog.";
            return;
        }
        else if (index == 2)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Silver Pog.";
            return;
        }
        else if (index == 3)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Gold Pog.";
            return;
        }
        else if (index == 4)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Gold Pog.";
            return;
        }
        else if (index == 5)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Gold Pog.";
            return;
        }
        else if (index == 6)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Diamond Pog.";
            return;
        }
        else if (index == 7)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Diamond Pog.";
            return;
        }
        else if (index == 8)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Diamond Pog.";
            return;
        }
        else if (index == 9)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for a Diamond Pog.";
            return;
        }
    }

    // Function used to check if the mouse is no longer hovering over 
    public void exitHover()
    {
        // Changes the description to the placeholder
        changingText.GetComponent<TextMeshProUGUI>().text = "Nothing...";
        return;
    }
}
