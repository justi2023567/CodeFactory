/****************************** Script Header ******************************\
Script Name: OreHealth.cs
Project: CodeFactory
Author: Brandon
Editors: Brandon
Last Edited: October 12, 2023

<Description>
Holds the variables that holds the health for the ore.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreHealth : MonoBehaviour
{
    // The health for the ores (basically its hp)
    public int health;
    //If it will be destroyed
    public bool picked = false;
}
