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

public class LoadingController : MonoBehaviour
{
    //Create a list of gameobjects to hold the ores total
    public GameObject[] oresTotal;
    //Create a gameobject for the spawner
    public GameObject Spawner;
    //Create a gameobject for the back grey screen
    public GameObject Backscreen;
    //Create a gameobject for the loading text
    public GameObject LoadingText;
    //Create a gameobject for the lock text
    public GameObject LockText;
    //Create a gameobject for the player
    public GameObject player;

    //Create floats for the timer
    public float firerate = 7f;
    public float nextfire = 1f;

    // Update is called once per frame
    void Update()
    {
        //Set the oresTotal to all of the gameobjects in the scene with the tag "ore"
        oresTotal = GameObject.FindGameObjectsWithTag("ore");

        //If the oresTotal length is greater than 150
        if (oresTotal.Length >= 150)
        {
            //If timer ran out
            if (Time.time > nextfire)
            {
                //Reset timer
                nextfire = Time.time + firerate;
                //Start a Coroutine (Start a function that runs IEnumerators (explained later) for LimitReached
                StartCoroutine(LimitReached());
            }
        }
        else
        {
            //Set the players controller to stop playing
            player.GetComponent<PlayerController>().playing = false;
        }
    }

    //Creates a IEnumerator called LimitReached, a IEnumerator (in very simplified terms) --
    // -- is a void that is able to use wait functions to stop the script until a certain --
    // -- time is up
    public IEnumerator LimitReached()
    {
        //Deactivate the spawner of ores
        Spawner.SetActive(false);
        //IEnumerators (explained previously) can use this function, to WaitForSeconds --
        // -- which in this case is 12 (f stands for a float value so there can be values --
        // -- like 10.5 seconds)
        yield return new WaitForSeconds(12f);
        //Deactivate the background screen
        Backscreen.SetActive(false);
        //Deactivate the loading text
        LoadingText.SetActive(false);
        //Activate the lock text
        LockText.SetActive(true);
        //Set the player's controller to playing
        player.GetComponent<PlayerController>().playing = true;
        //StopAllCoroutines prevents any other Coroutines from running --
        // -- which prevents code replaying multiple times
        StopAllCoroutines();
        //Destroy function deletes this (which in this case is this whole script)
        Destroy(this);
    }
}
