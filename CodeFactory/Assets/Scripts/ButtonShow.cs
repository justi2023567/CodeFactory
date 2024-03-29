﻿/****************************** Script Header ******************************\
Script Name: ButtonShow.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Shows buttons or something like that.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    //Create a list of gameobjects that need to be shown
    public GameObject[] showObj;
    //Create a list of gameobjects that need disabled
    public GameObject[] disableObj;

    //Create a int with the current press state starting at 0
    public int pressState = 0;

    //When a button is pressed
    public void OnPress()
    {
        //If the pressed state is 1
        if (pressState == 1)
        {
            //foreach gameobject that needs shown
            foreach (GameObject obj in showObj)
            {
                //Deactivate that object
                obj.SetActive(false);
            }
            //Reset pressState
            pressState = 0;
            //Return to leave the void instead of running the code after this
            return;
        }
        //If the pressed state is 0
        if (pressState == 0)
        {
            //foreach gameobject that needs shown
            foreach (GameObject obj in showObj)
            {
                //Activate that object
                obj.SetActive(true);
            }
            //foreach gameobject that needs disabled
            foreach (GameObject obj in disableObj)
            {
                //Deactivate that object
                obj.SetActive(false);
            }
            //Reset pressState
            pressState = 1;
            //Return to leave the void instead of running the code above this
            return;
        }
    }
}
