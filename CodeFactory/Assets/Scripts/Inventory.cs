/****************************** Script Header ******************************\
Script Name: Inventory.cs
Project: CodeFactory
Author: Brandon
Editors: Brandon

<Description>
Contains the inventory system.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This code was made by Brandon, and this is the actual code that works in the background in order for the number to change in the UI, while having a test key in order we can test 
The Sell function and the buy function on the Spongebob Bot.
*/
public class Inventory : MonoBehaviour
{
    // A keycode you can edit on Unity under this script
    public KeyCode addOresButton;

    // Variables to count collected Ores
    public int stoneCount = 0;
    public int coalCount = 0;
    public int ironCount = 0;
    public int goldCount = 0;
    public int diamondCount = 0;

    // Variables to count Pogs (in-game currency)
    // Higher level pogs can not be traded for lower level pogs (Ex. You can trade 10 pogs for 1 bronze pog but you can't trade 1 bronze pog for 10 pogs)
    public int pogCount = 0;
    public int bronzePogCount = 0; // Same as 10 Pogs
    public int silverPogCount = 0; // Same as 10 Bronze Pogs
    public int goldPogCount = 0; // Same as 10 Silver Pogs
    public int diamondPogCount = 0; // Same as 10 Gold Pogs

    public void FixedUpdate()
    {
        // Gives 1 of every ore and 10,000 pogs to test the selling system (DEV ONLY)
        if (Input.GetKeyDown(addOresButton))
        {
            stoneCount++;
            coalCount++;
            ironCount++;
            goldCount++;
            diamondCount++;
            pogCount += 10000;
            bronzePogCount += 1000;
            silverPogCount += 100;
            goldPogCount += 10;
            diamondPogCount++;
        }
    }
}
