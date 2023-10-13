/****************************** Script Header ******************************\
Script Name: ArmBotScript.cs
Project: CodeFactory
Author: Justin
Editors: Justin, Macarios
Last Edited: October 12, 2023

<Description>
Contains the functions of armbot. Allows armbot to grab items nearby it.
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArmBotScript : MonoBehaviour
{
    //Create a gameobject
    public GameObject Sphere;
    //Create a gameobject
    public GameObject Target;

    void Update()
    {
        //If sphere (created previously) exists and target (created previously) exists
        if (Sphere != null && Target != null)
        {
            //Set sphere's positon to move towards the target
            Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, Target.transform.position, 0.20f);
        }

        /* if (Sphere.transform.position == Target.transform.position)
        {
            Sphere.transform.position = new Vector3(0.0f, 6.0f, 4.0f);
            Sphere = null; //Unused Code
        }*/
    }

    //If an object collides with the armbot's collider
    private void OnTriggerEnter(Collider other)
    {
        //If the other object is tagged "Sphere"
        if (other.tag == "Sphere")
        {
            //Set sphere (created previously) to this object
            Sphere = other.gameObject;
            //Set the other gameobjects rigidbody to kinematic (which essentially freezes the object)
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
