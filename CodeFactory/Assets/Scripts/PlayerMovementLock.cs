/****************************** Script Header ******************************\
Script Name: PlayerMovementLock.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios
Last Edited: October 12, 2023

<Description>
Contains the functions for the players movement while the camera is in its
locked position. Camera in locked position just means that the camera is locked 
onto the player.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementLock : MonoBehaviour
{
    //Create a transform
    public Transform tf;
    //Create a quaternion (explained in PlayerMovement script)
    public Quaternion ttf;

    //Create a gameobject for the players body
    public GameObject PlayerBody;

    //Create a gameobject for the camera
    public GameObject Camera;

    //Create a script variable for the player's controller
    public PlayerController pm;

    // Update is called once per frame
    public void FixedUpdate()
    {
        //If the player controller is playing
        if (pm.playing == true)
        {
            //// * Cam controls *

            //Set cursor mode to locked
            Cursor.lockState = CursorLockMode.Locked;
            //Set cursor visibility to false
            Cursor.visible = false;

            //ttf.x = Mathf.Clamp(ttf.x, -60f, 60f); Unused code

            //Subtract to the quaternion's y by the axis of "Mouse X" times the mouse sensitivity times (-1)
            ttf.y -= Input.GetAxis("Mouse X") * pm.mousesens * (-1);
            //Set the transforms local rotation (not relative to the game world) --
            // -- to Quaternion.Euler and the value of 0f (f for float), y, and 0f of the quaternion (stated previously)
            tf.localRotation = Quaternion.Euler(0.0f, ttf.y, 0.0f);
            
            //// * End Cam controls *

            //Make the camera the parent of this transform
            Camera.transform.parent = this.transform;

            //Set temporary variable for forward of the transform
            Vector3 camF = tf.forward;
            //Set temporary variable for right of the transform
            Vector3 camR = tf.right;

            //Set the y on the camera is 0
            camF.y = 0;

            //Normalize each value
            camF = camF.normalized;
            camR = camR.normalized;

            //Explaination for this code is in PlayerMovementFree script

            //If the key W is pressed but not the key A and not the key D
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //Move the character forward from the camera's perspective times the movement speed times the movement percent multiplier
                this.transform.position += camF * (pm.movespeed * pm.movespeedperc);
            }
            //If the key W is pressed and A key is pressed but the D key is not pressed
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //Move the character forward (with 6% speed)
                this.transform.position += camF * (pm.movespeed * pm.movespeedperc - .06f);
                //Move the character left (with 4% speed)
                this.transform.position -= camR * (pm.movespeed * pm.movespeedperc - .04f);
                return;
            }
            //If the key W is pressed but A key is not pressed but D key is pressed
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //Move the character forward (with 6% speed)
                this.transform.position += camF * (pm.movespeed * pm.movespeedperc - .06f);
                //Move the character right (with 4% speed)
                this.transform.position += camR * (pm.movespeed * pm.movespeedperc - .04f);
                return;
            }
            //If the key A is pressed alone
            if (Input.GetKey(KeyCode.A))
            {
                //Move the character left by the movement speed times the movement speed percent multiplier
                this.transform.position -= camR * (pm.movespeed * pm.movespeedperc);
            }
            //If the key S is pressed but A key is not pressed and the D key is not pressed
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //Move the character backward from the camera's perspective times the movement speed times the movement percent multiplier
                this.transform.position -= camF * (pm.movespeed * pm.movespeedperc);
            }
            //If the key S is pressed but A key is pressed but the D key is not pressed
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //Move the character backward (with 6% speed)
                this.transform.position -= camF * (pm.movespeed * pm.movespeedperc - .06f);
                //Move the character left (with 10% speed)
                this.transform.position -= camR * ((pm.movespeed * pm.movespeedperc) * .1f);
            }
            //If the key S is pressed but A key is not pressed but the D key is pressed
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //Move the character backward (with 6% speed)
                this.transform.position -= camF * (pm.movespeed * pm.movespeedperc - .06f);
                //Move the character right (with 10% speed)
                this.transform.position += camR * ((pm.movespeed * pm.movespeedperc) * .1f);
            }
            //If the D key is pressed alone
            if (Input.GetKey(KeyCode.D))
            {
                //Move the character right by the movement speed times the movement speed percent multiplier
                this.transform.position += camR * (pm.movespeed * pm.movespeedperc);
            }
        }
    }
    //Testing

    public int avgFrameRate;
    public Text display_Text;

    public void Update()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        display_Text.text = "FPS: " + avgFrameRate.ToString();
    }
}
