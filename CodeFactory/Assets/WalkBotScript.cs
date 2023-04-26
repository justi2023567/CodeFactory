using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBotScript : MonoBehaviour {

    public GameObject[] goals;
    public Transform tMin;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goals = GameObject.FindGameObjectsWithTag("ore");

        foreach (GameObject t in goals) {
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ore")
        {
            other.tag = "Collected";
        }
    }
}

