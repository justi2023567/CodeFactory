using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeHighlight : MonoBehaviour
{
    // needs comments
    private string input;

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);

        if (s.Contains("player") || s.Contains("Player"))
        {
            Debug.Log("player is not a vaild command");
        }
    }
}
