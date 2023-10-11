/****************************** Script Header ******************************\
Script Name: AttemptedCamColl.cs
Project: CodeFactory
Author: Macarios
Editors: Macarios

<Description>
Makes it so that the camera can't collide with something and get stuck.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptedCamColl : MonoBehaviour
{
    //OnTriggerEnter activates when a collider collides with the camera collision
    private void OnTriggerEnter(Collider other)
    {
        //Make the other objects rigidbody kinematic
        other.GetComponent<Rigidbody>().isKinematic = true;
    }
}
