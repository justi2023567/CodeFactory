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
/*
This code was made code factory, and this file is used for allowing the player to open a menu 
for the code blocks and allowing them to interact with the robot in that regard.
*/
public class CodeBlocks : MonoBehaviour
{
    //Create a gameobject for the entire codeblocks menu
    public GameObject CodeBlocksMenu;

    public GameObject UI_Icons;
    //Create a key code for the interact button
    public KeyCode InteractButton;

    //Create floats for a timer
    public float firerate;
    public float nextfire;

    //Create a bool if it is open or not
    public bool open = false;

    //Create a script variable
    public CheckBlocks controller;

    //Create a scirpt variable for Player's controller
    public PlayerController pc;

    //Create a gameobject for the object last collided with
    public GameObject LastCollided;

    public void Update()
    {
        //If timer has run out
        if (Time.time > nextfire)
        {
            //Reset timer
            nextfire = Time.time + firerate;
            //If interact button key is pressed and the code menu is already open
            if (Input.GetKeyDown(InteractButton) && open == true && pc.playing == false)
            {
                //Set pc (created previously) playing to true
                pc.playing = true;
                //Set cursor lock state to locked, which prevents the cursor from leaving the game
                Cursor.lockState = CursorLockMode.Locked;
                //Set cursor visibility to false
                Cursor.visible = false;
                if (pc.open == false)
                {
                    // Enables the UI Icons
                    UI_Icons.SetActive(true);
                }
                //Deactivate the code blocks menu
                CodeBlocksMenu.SetActive(false);
                //Set open to false
                open = false;
                //Return to exit the void instead of running the code below
                return;
            }
            //If interact button key is pressed and the code menu is not already open
            if (Input.GetKeyDown(InteractButton) && open == false && pc.playing == true && pc.open == false)
            {
                //Set pc (created previously) playing to false
                pc.playing = false;
                //Set cursor lock state to none, which allows the player to move the mouse freely
                Cursor.lockState = CursorLockMode.None;
                //Set cursor visibility to true
                Cursor.visible = true;
                //Disables the UI Icons
                UI_Icons.SetActive(false);
                //Activate the code blocks menu
                CodeBlocksMenu.SetActive(true);
                //Set open to true
                open = true;
                //Return to exit the void instead of running the code above
                return;
            }
        }
    }

    //OnTriggerExit applies when what ever collider has left the collider of the code blocks menu
    private void OnTriggerExit(Collider other)
    {
        //If the others gameobject tag is bot and the controller has no error
        if (other.tag == "Bot" && controller.error == false)
        {
            //Set the code of the robot to be the code of the controller
            other.GetComponent<WalkBotScript>().code = controller.code;
        }
    }
}
