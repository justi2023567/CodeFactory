using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeHighlight : MonoBehaviour
{
    //Creates a empty string for the input of the player
    private string input;

    //When the void readstringinput is called with the argument of s
    public void ReadStringInput(string s)
    {
        //Set the input (created previously) to the argument
        input = s;
        //Testing: Log the input
        Debug.Log(input);

        //If the argument contains the string "player" or "Player"
        if (s.Contains("player") || s.Contains("Player"))
        {
            //Testing: Log the error saying "player is not a valid command"
            Debug.Log("player is not a valid command");
        }
    }
}
