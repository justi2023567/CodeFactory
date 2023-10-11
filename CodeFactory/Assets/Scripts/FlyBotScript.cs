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
using UnityEngine.AI;

/*
This code is used for Flybot, and he/she collects the ore the remains after mining it.
And returns it to the garage. Cannot code this one in game.
*/
public class FlyBotScript : MonoBehaviour
{
    //Create a list of gameobjects that holds all of the "goals" (ores and targets) that the flybot uses
    public GameObject[] goals;
    //Create a transform that holds the closest goal in goals (created previously)
    public Transform tMin;
    //Creates a vector3 with the start position
    Vector3 startPos;
    public GameObject oreChunckClosest;

    // Start is called before the first frame update
    void Start()
    {
        //Set the vector3 startPos to the walkbots current starting position
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Assigns all game objects with the tag "ore" as the variable "goals"
        goals = GameObject.FindGameObjectsWithTag("OreRemains");

        // Checks if goals is 0
        if (goals.Length < 1)
        {
            //Get the NavMeshAgent off this object
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            //Set the NavMeshAgents target as the starting position
            agent.destination = startPos;
        }
        else
        {
            //foreach gameobject in goals (created previously)
            foreach (GameObject t in goals)
            {
                //Creates a infinitely sized distance as a temporary value
                float minDist = Mathf.Infinity;
                //Finds location of the current walkbot
                Vector3 currentPos = transform.position;
                //foreach gameobject in goals (created previously) * loops twice to find the shortest distance out of all of the ores *
                foreach (GameObject tt in goals)
                {
                    //Sets a new variable "dist" as the Vector3's distance between a ore and the flybots current position
                    float dist = Vector3.Distance(tt.transform.position, currentPos);
                    //If the distance between the ore and the flybot is smaller than the minimum distance
                    if (dist < minDist)
                    {
                        //Set the new minimum distance to that distance
                        minDist = dist;
                        //Set the closest transform to that ore
                        tMin = tt.transform;
                        oreChunckClosest = tMin.gameObject;

                        // * Goes down over an ore **NOT WORKING**
                        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.y), new Vector3(tMin.position.x, 0, tMin.position.y)) <= 3.48)
                        {
                            //Debug.Log("Working");
                            this.GetComponent<NavMeshAgent>().baseOffset = 0;
                        }
                        else
                        {
                            this.GetComponent<NavMeshAgent>().baseOffset = 40;
                        }
                        // *
                    }
                }
                //Get the NavMeshAgent off this object
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                //Set the NavMeshAgents target as the closest ore
                agent.destination = tMin.position;
            }
        }
    }
    //If another object collides with the walkbot
    public void OnTriggerEnter(Collider other)
    {

        Destroy(oreChunckClosest.gameObject, 2f);
    }
}

