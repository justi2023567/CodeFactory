/****************************** Script Header ******************************\
Script Name: buildingSystem.cs
Project: CodeFactory
Author: Brandon
Editors: Brandon
Last Edited: November 10, 2023

<Description>
Contains the functions for the building system.
\***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingSystem : MonoBehaviour
{
    // Holds the players gameobject
    public GameObject player;

    // Holds the buildings
    public GameObject cube;

    public void onClick()
    {
        // Spawns in the build that is refrenced
        Instantiate(cube, player.transform.position, Quaternion.identity);
    }
}
