/****************************** Script Header ******************************\
Script Name: 
Project: CodeFactory
Author: 
Editors: 

<Description>

\***************************************************************************/

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

    // Holds the gameobject for their respective systems
    public GameObject buyingSystem;
    public GameObject sellingSystem;

    // Creates a gameobject for the text thats going to change
    public GameObject changingText;

    // Creates a gameobject for the popup text that appears telling you that you're poor
    public GameObject yourePoor;
    public GameObject yourePoorText;

    public IEnumerator timer()
    {
        yield return new WaitForSeconds(3f);
        yourePoor.SetActive(false);
    }
    // Function used to check if the button was clicked
    public void buttonClickedBuy()
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
        } else
        {
            yourePoorText.GetComponent<TextMeshProUGUI>().text = "Not Enough Money!!";
            yourePoor.SetActive(true);
            StartCoroutine(timer());
        }
    }
    public void buttonClickedSell()
    {
        // Checks if the index is the same as the index that you clicked and if you have enough of the currency to buy the item
        if (index == 0 && script.stoneCount >= 10)
        {
            script.pogCount++;
            script.stoneCount -= 10;
            return;
        }
        if (index == 1 && script.coalCount >= 5)
        {
            script.pogCount++;
            script.coalCount -= 5;
            return;
        }
        // Continue here later
        if (index == 2 && script.ironCount >= 1)
        {
            script.pogCount++;
            script.ironCount -= 1;
            return;
        }
        if (index == 3 && script.goldCount >= 1)
        {
            script.pogCount += 5;
            script.goldCount -= 1;
            return;
        }
        if (index == 4 && script.diamondCount >= 1)
        {
            script.pogCount += 10;
            script.diamondCount -= 1;
            return;
        }
        if (index == 5 && script.diamondCount >= 1)
        {
            script.bronzePogCount++;
            script.diamondCount -= 1;
            return;
        } else
        {
            yourePoorText.GetComponent<TextMeshProUGUI>().text = "Not Enough Resources!!";
            yourePoor.SetActive(true);
            StartCoroutine(timer());
        }
    }

    // Function used to check if the mouse is hovering on top of the item
    public void onHoverBuy()
    {
        // If the index is the same as the index you are hovering over, the description gets changed to the description of that item
        if (index == 0)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Bronze Pog.";
            return;
        }
        else if (index == 1)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Silver Pog.";
            return;
        }
        else if (index == 2)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Silver Pog.";
            return;
        }
        else if (index == 3)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Gold Pog.";
            return;
        }
        else if (index == 4)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Gold Pog.";
            return;
        }
        else if (index == 5)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Gold Pog.";
            return;
        }
        else if (index == 6)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Diamond Pog.";
            return;
        }
        else if (index == 7)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Diamond Pog.";
            return;
        }
        else if (index == 8)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Diamond Pog.";
            return;
        }
        else if (index == 9)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for buying a Diamond Pog.";
            return;
        }
    }

    public void onHoverSell()
    {
        if (index == 0)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for selling stone.";
            return;
        }
        else if (index == 1)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for selling coal.";
            return;
        }
        else if (index == 2)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for selling iron.";
            return;
        }
        else if (index == 3)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for selling gold.";
            return;
        }
        else if (index == 4)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for selling diamond.";
            return;
        }
        else if (index == 5)
        {
            changingText.GetComponent<TextMeshProUGUI>().text = "Placeholder description for selling diamond.";
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

    public void buyButtonClicked()
    {
        buyingSystem.SetActive(true);
        sellingSystem.SetActive(false);
    }

    public void sellButtonClicked()
    {
        sellingSystem.SetActive(true);
        buyingSystem.SetActive(false);
    }
}
