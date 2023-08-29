using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlocks : MonoBehaviour
{
    //Mine: 1
    //Store: 2
    //Walk: 3
    //Return: 4
    //If: 5
    //End: 6

    //For the if statements when the bot is breaking them down, create a variable that starts at 0 (not activated) check if the statement is true

    //Create a string for the output
    public string output = "N/A";

    //Create bools for it has the requirements to be a code
    public bool hasIf = false;
    public bool hasEnd = false;

    //Create a bool for if it errors
    public bool error = false;
    //Create a gameobject for text
    public GameObject text;

    //Create a empty string for the code
    public string code = "";

    // Update is called once per frame
    public void Check()
    {
        //If the code is not empty
        if (code != "")
        {
            //Set the code to empty
            code = "";
        }
        //foreach child of this gameobject
        foreach (Transform child in transform)
        {
            //If the childs blockvalue is 5
            if (child.GetComponent<BlockValue>().Value == "5")
            {
                //Set hasIf to true
                hasIf = true;
            }
            //If the childs blockvalue is 6
            if (child.GetComponent<BlockValue>().Value == "6")
            {
                //Set hasEnd to true
                hasEnd = true;
            }
            //If hasIf is true but there is no hasEnd
            if (hasIf == true && hasEnd == false)
            {
                //Set error to true
                error = true;
                //Show error text
                text.SetActive(true);
            }
            //If hasIf is true and there is hasEnd
            if (hasIf == true && hasEnd == true)
            {
                //Set error to false
                error = false;
                //Set hasEnd to false
                hasEnd = false;
                //Set hasIf to false
                hasIf = false;
                //Deactivate the error text
                text.SetActive(false);
            }
            //Add the childs blockvalue number to the code
            code += child.GetComponent<BlockValue>().Value;
        }
    }
}