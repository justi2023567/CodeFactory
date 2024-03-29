﻿/****************************** Script Header ******************************\
Script Name: SettingsController.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Contains the functions for the buttons used in the settings menu.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    //Create gameobjects for every button under settings
    public GameObject GeneralSettings;
    public GameObject General;
    public GameObject Controls;
    public GameObject Audio;

    //If general is pressed
    public void GeneralButton()
    {
        //Deactivate general settings
        GeneralSettings.SetActive(false);
        //Activate the settings under general (wording is a little weird)
        General.SetActive(true);
    }

    //If controls is pressed
    public void ControlsButton()
    {
        //Deactivate general settings
        GeneralSettings.SetActive(false);
        //Activate the settings under controls
        Controls.SetActive(true);
    }

    //If audio is pressed
    public void AudioButton()
    {
        //Deactivate general settings
        GeneralSettings.SetActive(false);
        //Activate the settings under audio
        Audio.SetActive(true);
    }
    
    //If back is pressed
    public void Back()
    {
        //Deactivate all settings under these
        General.SetActive(false);
        Controls.SetActive(false);
        Audio.SetActive(false);
        //Reactivate the general settings
        GeneralSettings.SetActive(true);
    }
}
