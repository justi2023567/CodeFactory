using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyBotScript : MonoBehaviour
{
    // needs more detailed comments
    public GameObject[] goals;
    public Transform tMin;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Assigns all game objects with the tag "ore" as the variable "goals"
        goals = GameObject.FindGameObjectsWithTag("ore");

        // Checks if goals is 0
        if (goals.Length < 1)
        {
            // Returns robot to starting position
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = startPos;
        }
        else
        {
            foreach (GameObject t in goals)
            {
                // Finds location of ores
                float minDist = Mathf.Infinity;
                Vector3 currentPos = transform.position;
                foreach (GameObject tt in goals)
                {
                    // Finds the closest ore to the robot
                    float dist = Vector3.Distance(tt.transform.position, currentPos);
                    if (dist < minDist)
                    {
                        // Goes down over an ore **NOT WORKING**
                        minDist = dist;
                        tMin = tt.transform;
                        if (Vector3.Distance(transform.position, tMin.position) < 1)
                        {
                            this.GetComponent<NavMeshAgent>().baseOffset = 0;
                        }
                    }

                }
                // Moves robot to the closest ore
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = tMin.position;
            }
        }
        // Lands when returning to start pos **NOT WORKING**
        if (Vector3.Distance(transform.position, startPos) < 1)
        {
            this.GetComponent<NavMeshAgent>().baseOffset = 0;
        }
        else
        {
            this.GetComponent<NavMeshAgent>().baseOffset = 60;
        }
    }
}
