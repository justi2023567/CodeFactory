using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBotScript : MonoBehaviour {

    public GameObject[] goals;
    public Transform tMin;

    public string code = "";

    public bool canMine = false;

    // Start is called before the first frame update

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
                if (character == "1")
                {
                    canMine = true;
                }
                if (character == "3")
                {
                    goals = GameObject.FindGameObjectsWithTag("ore");

                    foreach (GameObject t in goals)
                    {
                        float minDist = Mathf.Infinity;
                        Vector3 currentPos = transform.position;
                        foreach (GameObject tt in goals)
                        {
                            float dist = Vector3.Distance(tt.transform.position, currentPos);
                            if (dist < minDist)
                            {
                                minDist = dist;
                                tMin = tt.transform;
                            }
                        }
                        NavMeshAgent agent = GetComponent<NavMeshAgent>();
                        agent.destination = tMin.position;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ore" && canMine == true)
        {
            other.tag = "Collected";
        }
        //Storing (Later)
    }
}

