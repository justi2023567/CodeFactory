/****************************** Script Header ******************************\
Script Name: PlayerMovementFree.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Contains the functions for the players movement while the camera is in its
free position. Camera in free position just means that the camera is basically 
in free cam mode and can move anywhere and doesn't care about the player.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFree : MonoBehaviour
{
    //Create a transform
    public Transform tf;
    //Create a quaternion (explained in PlayerMovement script)
    public Quaternion ttf;

    //Create a gameobject for the players body
    public GameObject PlayerBody;

    //Create a script variable for the player's controller
    public PlayerController pm;

    // Update is called once per frame
    public void FixedUpdate()
    {
        //If the player controller is playing
        if (pm.playing == true)
        {
            //Remove this objects parent object
            this.transform.parent = null;

            //// * Cam controls *

            //Set cursor mode to locked
            Cursor.lockState = CursorLockMode.Locked;
            //Set cursor visibility to false
            Cursor.visible = false;

            //Add to the quaternion's x by the axis of "Mouse Y" times the mouse sensitivity times (-1)
            ttf.x += Input.GetAxis("Mouse Y") * pm.mousesens * (-1);
            //Clamp (Restrict) the movement of the quaternion's x to -60 and 60
            ttf.x = Mathf.Clamp(ttf.x, -60f, 60f);

            //Subtract to the quaternion's y by the axis of "Mouse X" times the mouse sensitivity times (-1)
            ttf.y -= Input.GetAxis("Mouse X") * pm.mousesens * (-1);

            //Set the transforms local rotation (not relative to the game world) --
            // -- to Quaternion.Euler and the value of x, y, and z of the quaternion (stated previously)
            tf.localRotation = Quaternion.Euler(ttf.x, ttf.y, ttf.z);

            //// * End Cam controls *

            //Set temporary variable for forward of the transform
            Vector3 camF = tf.forward;
            //Set temporary variable for right of the transform
            Vector3 camR = tf.right;

            //Normalize each value
            camF = camF.normalized;
            camR = camR.normalized;

            //The future segment may be confusing and repetitive, but this is for a reason. --
            // -- These are the movement speeds for different keys being pressed, but there --
            // -- is a preventative measure applied to combat against strafing (a technique --
            // -- where if the user holds W + A, or W + D to get a movement boost). That is --
            // -- why there are lines like ^if W is pressed but not A or D^ below

            //If the key W is pressed but A key is not pressed and D key is not pressed
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //Move the character forward from the camera's perspective times the movement speed times the movement percent multiplier
                transform.position += camF * pm.movespeed * pm.movespeedperc;
            }
            //If the key W is pressed and A key is pressed but the D key is not pressed
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //Move the character forward from the camera's perspective times the movement speed times the movement percent multiplier
                transform.position += camF * pm.movespeed * pm.movespeedperc;
            }
            //If the key W is pressed but A key is not pressed but D key is pressed
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //Move the character forward from the camera's perspective times the movement speed times the movement percent multiplier
                transform.position += camF * pm.movespeed * pm.movespeedperc;
            }
            //If the key A is pressed alone
            if (Input.GetKey(KeyCode.A))
            {
                //Move the character to the left times the movement speed times the movement percent multiplier
                transform.position -= camR * pm.movespeed * pm.movespeedperc;
            }
            //If the key S is pressed alone
            if (Input.GetKey(KeyCode.S))
            {
                //Move the character backwards times the movement speed times the movement percent multiplier
                transform.position -= camF * pm.movespeed * pm.movespeedperc;
            }
            //If the key D is pressed alone
            if (Input.GetKey(KeyCode.D))
            {
                //Move the character to the right times the movement speed times the movement percent multiplier
                transform.position += camR * pm.movespeed * pm.movespeedperc;
            }
        }
    }
}
