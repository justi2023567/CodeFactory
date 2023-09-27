using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyBotScript : MonoBehaviour
{
    //Create a list of gameobjects that holds all of the "goals" (ores and targets) that the flybot uses
    public GameObject[] goals;
    //Create a transform that holds the closest goal in goals (created previously)
    public Transform tMin;
    //Creates a vector3 with the start position
    Vector3 startPos;
    public GameObject[] walkBot;

    // Start is called before the first frame update
    void Start()
    {
        //Set the vector3 startPos to the walkbots current starting position
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
