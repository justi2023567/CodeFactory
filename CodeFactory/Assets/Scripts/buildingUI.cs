/****************************** Script Header ******************************\
Script Name: buildingUI.cs
Project: CodeFactory
Author: Brandon
Editors: Brandon
Last Edited: November 10, 2023

<Description>
Contains the functions for the UI of the building system.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buildingUI : MonoBehaviour
{
    // Holds the building system's UI gameobject
    public GameObject building;

    // Holds the building system's UI icon
    public GameObject buildingIcon;

    // Holds the building system's on and off icons
    public Sprite buildingIconOn;
    public Sprite buildingIconOff;

    // Creates a keycode for the interact button
    public KeyCode InteractButton;

    //Create a scirpt variable for Player's controller
    public PlayerController pc;

    // Used to check if the building system's UI is open
    public bool open = false;

    // Update is called once per frame
    void Update()
    {
        // If the interact button is pressed and the building system's UI is not open
        if (Input.GetKeyDown(InteractButton) && open == false && pc.playing == true && pc.open == false)
        {
            // Turns the inventory icon to its on state
            buildingIcon.GetComponent<Image>().sprite = buildingIconOn;
            // Sets pc.playing to false
            pc.playing = false;
            // Activate the building system's UI
            building.SetActive(true);
            // Set cursor lock state to none, which allows the player to move the mouse freely
            Cursor.lockState = CursorLockMode.None;
            // Set cursor visibility to true
            Cursor.visible = true;
            // Set open to true
            open = true;
            return;
        }
        // If the interact button is pressed and the building system's UI is open
        if (Input.GetKeyDown(InteractButton) && open == true && pc.playing == false)
        {
            // Sets pc.playing to true
            pc.playing = true;
            // Deactivate the building system's UI
            building.SetActive(false);
            // Set cursor lock state to locked, which prevents the cursor from leaving the game
            Cursor.lockState = CursorLockMode.Locked;
            // Set cursor visibility to false
            Cursor.visible = false;
            // Set open to false
            open = false;
            return;
        }
        // If the inventory is not open
        if (open == false)
        {
            // Turns the building system's icon to its off state
            buildingIcon.GetComponent<Image>().sprite = buildingIconOff;
        }
    }
}
