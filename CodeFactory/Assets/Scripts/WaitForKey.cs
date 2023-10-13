/****************************** Script Header ******************************\
Script Name: WaitForKey.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Makes it so that there is a delay between key presses when switching camera modes.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForKey : MonoBehaviour
{
    //Create a event for a key
    public Event keyEvent;
    //Create a text variable
    public Text text;

    //Create a script variable for the Player Controller
    public PlayerController pc;

    //Create a gameobject
    public GameObject obj;

    //When the object is clicked
    public void OnClick(GameObject clicked)
    {
        //Set the empty gameobject to what was clicked
        obj = clicked;
    }

    //OnGUI handles GUI objects
    public void OnGUI()
    {
        //Key event checks what key was previously pressed
        keyEvent = Event.current;
        //If the keyevent is a key, and there is a object that was clicked
        if (keyEvent.isKey == true && obj == this.gameObject)
        {
            //Create a temporary variable with holds the string of what key was pressed
            var keyText = keyEvent.keyCode.ToString();
            //Set the text (created previously) to what key was pressed
            text.text = keyText;
            //Set the camera state changing key to what ever key was pressed
            pc.CameraStateKey = keyEvent.keyCode;
            //Set the object that was clicked on to null
            obj = null;
        }
    }
}
