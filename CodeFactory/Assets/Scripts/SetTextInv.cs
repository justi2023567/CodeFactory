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

public class SetTextInv : MonoBehaviour
{
    //Create a text variable
    public Text text;

    //Create multiple bools for if there is any of these items
    public bool ifstone;
    public bool ifcoal;
    public bool ifiron;
    public bool ifgold;
    public bool ifdiamond;

    //Create a script variable for Inventory
    public Inventory playerInventory;

    // Update is called once per frame
    void Update()
    {
        //If there is stone in the inventory
        if (ifstone == true)
        {
            //Set the text (created previously) to "Stone: " + the amount of stone
            text.text = "Stone: " + playerInventory.stoneCount.ToString();
        }
        //If there is coal in the inventory
        if (ifcoal == true)
        {
            //Set the text (created previously) to "Coal: " + the amount of coal
            text.text = "Coal: " + playerInventory.coalCount.ToString();
        }
        //If there is iron in the inventory
        if (ifiron == true)
        {
            //Set the text (created previously) to "Iron: " + the amount of iron
            text.text = "Iron: " + playerInventory.ironCount.ToString();
        }
        //If there is gold in the inventory
        if (ifgold == true)
        {
            //Set the text (created previously) to "Gold: " + the amount of gold
            text.text = "Gold: " + playerInventory.goldCount.ToString();
        }
        //If there is diamond in the inventory
        if (ifdiamond == true)
        {
            //Set the text (created previously) to "Diamond: " + the amount of diamond
            text.text = "Diamond: " + playerInventory.diamondCount.ToString();
        }
    }
}
