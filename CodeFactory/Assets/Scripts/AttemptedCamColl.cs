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

public class AttemptedCamColl : MonoBehaviour
{
    //OnTriggerEnter activates when a collider collides with the camera collision
    private void OnTriggerEnter(Collider other)
    {
        //Make the other objects rigidbody kinematic
        other.GetComponent<Rigidbody>().isKinematic = true;
    }
}
