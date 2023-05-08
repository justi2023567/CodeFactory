using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConBeltScript : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public List<GameObject> onBelt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= onBelt.Count -1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
        }
    }

    // When something collides with belt
    private void OnTriggerEnter(Collider other)
    {
        onBelt.Add(other.gameObject);
    }

    // When something leaves the belt
    private void OnTriggerExit(Collider other)
    {
        onBelt.Remove(other.gameObject);
    }
}
