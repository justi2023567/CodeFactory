/****************************** Script Header ******************************\
Script Name: Controller.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Controlls the codeblocks.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Create a list of gameobjects to snap to for the player controller
    public GameObject[] snapPC;
    //Create a list of gameobjects to snap to for the code blocks
    public GameObject[] snapCB;

    //Create a list of gameobjects for the program chip
    public GameObject[] programChip;
    //Create a list of gameobjects for the code blocks
    public GameObject[] codeBlocks;

    //Create a gameobject for the delete button
    public GameObject deleteBttn;

    //Create a gameobject for the player controllers content
    public GameObject PCContent;
    //Create a gameobject for the code blocks content
    public GameObject CBContent;

    //Create a void called Add that takes an arguement of a button
    public void Add(GameObject button)
    {
        //If the button that is given earlier has the parents name of Content CB
        if (button.transform.parent.name == "Content CB")
        {
            //foreach gameobject snap in snapCB list
            foreach (GameObject snap in snapCB)
            {
                //If the distance between the button and the snap position is less than .1f (f for float)
                if (Vector3.Distance(button.transform.position, snap.transform.position) <= .1f)
                {
                    //Set the used state to false
                    snap.GetComponent<SnapUse>().used = false;
                }
            }
            //foreach gameobject snap in snapPC list
            foreach (GameObject snap in snapPC)
            {
                //If the snap is not used
                if (snap.GetComponent<SnapUse>().used == false)
                {
                    //Set the buttons position to the snap position
                    button.transform.position = snap.transform.position;
                    //Set the parent of the button to PC Content
                    button.transform.parent = PCContent.transform;
                    //Set the snap used state to true
                    snap.GetComponent<SnapUse>().used = true;
                    //Return to exit the void instead of running code below
                    return;
                }
            }
        }
        //If the buttons parents name is Content PC
        if (button.transform.parent.name == "Content PC")
        {
            //foreach gameobject snap in snapPC list
            foreach(GameObject snap in snapPC)
            {
                //If the distance between the button's position and the snap position is less than .1f (f for float)
                if (Vector3.Distance(button.transform.position, snap.transform.position) <= .1f)
                {
                    //Set the snap used state to false
                    snap.GetComponent<SnapUse>().used = false;
                }
            }
            //foreach gameobject snap in snapCB list
            foreach (GameObject snap in snapCB)
            {
                //If the snap is not used
                if (snap.GetComponent<SnapUse>().used == false)
                {
                    //Set the buttons position to the snap position
                    button.transform.position = snap.transform.position;
                    //Set the buttons parent to the CB Content
                    button.transform.parent = CBContent.transform;
                    //Set the snap used state to true
                    snap.GetComponent<SnapUse>().used = true;
                    //Return to exit the void instead of running code above
                    return;
                }
            }
        }
    }
}
