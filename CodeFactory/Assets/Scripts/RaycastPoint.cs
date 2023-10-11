/****************************** Script Header ******************************\
Script Name: RaycastPoint.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios

<Description>
Uses raycasts to create connections between objects.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPoint : MonoBehaviour
{
    //Create a gameobject for the player
    public GameObject player;

    //Create a float and set it to Y
    public float Y = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set the rotation of this to (90, 0, 0, 1) in the format of (x, y, z, w)
        this.transform.rotation = new Quaternion(90, 0, 0, 1);

        //Create a temporary variable called hit (will be used by later code)
        RaycastHit hit;

        //If a physics raycast (a invisible very thin line), that shoots out from this transforms position --
        // --, shooting directly downward (opposite of Vector3.up), which uses hit (created previously)
        if (Physics.Raycast(this.transform.position, -Vector3.up, out hit))
        {
            //If the raycast hits and the distance is less than 2f (f for float)
            if (hit.distance < 2f)
            {
                //If the float Y = 0
                if (Y == 0)
                {
                    //Set Y to the players position y
                    Y = player.transform.position.y;
                }
                //If the float Y is greater than the players position y
                if (Y > player.transform.position.y)
                {
                    //Set the players position to itself but the Y is replaced by the Y value;
                    player.transform.position = new Vector3(player.transform.position.x, Y, player.transform.position.z);
                }
            }
            //else if the hit distance is greater than 2f
            else if (hit.distance > 2f)
            {
                //Reset Y to 0;
                Y = 0f;
            }
        }
    }
}
