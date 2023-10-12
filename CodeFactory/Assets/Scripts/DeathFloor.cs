/****************************** Script Header ******************************\
Script Name: DeathFloor.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Teleports you back to the respawn point if you fall off the map.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    //Gameobject that holds the position of where the character should be reset to
    public GameObject resetpoint;

    //When an object collides with the death floor
    private void OnTriggerEnter(Collider other)
    {
        //If the other object has the tag "Player"
        if (other.tag == "Player")
        {
            //Set the other objects position to the resetpoint created earlier
            other.transform.position = resetpoint.transform.position;
        }
    }
}
