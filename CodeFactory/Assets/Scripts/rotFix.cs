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

public class rotFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Sets this objects rotation to a new Quaternion (explained in PlayerMovement) with the parameters of this objects x, y, z, and w values
        //This ensures that the rotation is exactly its own rotation not relative to the game world
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.position.y, this.transform.position.z, 1);
    }
}
