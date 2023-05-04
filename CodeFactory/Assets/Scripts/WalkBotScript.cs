using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBotScript : MonoBehaviour {

    public GameObject[] goals;
    public Transform tMin;
    Vector3 startPos;

    public int InvContaining = 0;

    public string code = "";

    public bool canMine = false;
    public bool canStore = false;
    public bool returnon = false;

    public int invFullState = 0;

    // Start is called before the first frame update
    void Start() {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (code != "")
        {
            string[] characters = new string[code.Length];
            for (int i = 0; i < code.Length; i++)
            {
                characters[i] = System.Convert.ToString(code[i]);
            }
            foreach (string character in characters)
            {
                if (invFullState != 2)
                {
                    if (character == "1")
                    {
                        canMine = true;
                    }
                    if (character == "2")
                    {
                        canStore = true;
                    }
                    if (character == "3")
                    {
                        // Assigns all game objects with the tag "ore" as the variable "goals"
                        goals = GameObject.FindGameObjectsWithTag("ore");

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
                                    minDist = dist;
                                    tMin = tt.transform;
                                }

                            }
                            // Moves robot to the closest ore
                            NavMeshAgent agent = GetComponent<NavMeshAgent>();
                            agent.destination = tMin.position;
                        }
                    }
                    if (character == "4")
                    {
                        NavMeshAgent agent = GetComponent<NavMeshAgent>();
                        agent.destination = startPos;
                    }
                }
                if (character == "5")
                {
                    if (InvContaining == 5)
                    {
                        invFullState = 1;
                    }
                    else
                    {
                        invFullState = 2;
                    }
                }
                if (character == "6")
                {
                    invFullState = 1;
                }
            }

        }
        /*
        // Checks if goals is 0
        if (goals.Length < 1)
        {
            
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        // Blows up the ore using the ore tag
        if (other.tag == "ore" && canMine == true)
        {
            if (canStore == true)
            {
                InvContaining++;
            }
            this.GetComponent<OreMining>().blowup = true;
            this.GetComponent<OreMining>().collectOre = canStore;
        }
    }
}

