using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConBeltScript : MonoBehaviour
{
    //Creates a float for the belt speed
    public float speed;
    //Creates a Vector3 for the direction that the conveyer belt is running
    public Vector3 direction;
    //Creates a empty list of all of the items on the belt
    public List<GameObject> onBelt;

    // Update is called once per frame
    void Update()
    {
        //for every item on the belt
        for(int i = 0; i <= onBelt.Count -1; i++)
        {
            //Get the objects rigidbody and move it in the direction of the belt times the speed time the current time
            onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
        }
    }

    //When something collides with belt
    private void OnTriggerEnter(Collider other)
    {
        //Add the new collided object to the belt list
        onBelt.Add(other.gameObject);
    }

    //When something leaves the belt
    private void OnTriggerExit(Collider other)
    {
        //Remove the old collided object from the belt list
        onBelt.Remove(other.gameObject);
    }
}
