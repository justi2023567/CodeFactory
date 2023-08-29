using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForKeyInventory : MonoBehaviour
{
    //Create a event for a key
    public Event keyEvent;
    //Create a text variable
    public Text text;

    //Create a script variable for Player Controller
    public PlayerController pc;

    //Create a gameobject
    public GameObject obj;

    //When an object is clicked
    public void OnClick(GameObject clicked)
    {
        //Set the empty obj to what ever was clicked
        obj = clicked;
    }

    //OnGUI handles GUI objects
    public void OnGUI()
    {
        //Sets the key to what ever key was pressed previously
        keyEvent = Event.current;

        //If the key is a real key and there was an object that was clicked on
        if (keyEvent.isKey == true && obj == this.gameObject)
        {
            //Create a temporary variable to hold the string of the key that was pressed
            var keyText = keyEvent.keyCode.ToString();
            //Set the text (created previously) to what ever key was pressed
            text.text = keyText;
            //Set the inventory change key to what ever key was pressed
            pc.InventoryStateKey = keyEvent.keyCode;
            //Set the object that was clicked on to null
            obj = null;
        }
    }
}
