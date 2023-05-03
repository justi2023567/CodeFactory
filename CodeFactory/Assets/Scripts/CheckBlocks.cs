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

    public string output = "N/A";

    public string code = "";

    // Update is called once per frame
    public void Check()
    {
        if (code != "")
        {
            code = "";
        }
        foreach (Transform child in transform)
        {
            Debug.Log(child);
            code += child.GetComponent<BlockValue>().Value;
        }
    }
}