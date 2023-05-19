using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArmBotScript : MonoBehaviour
{

    public GameObject Sphere;
    public GameObject Target;

    void Update()
    {
        if (Sphere != null)
        {
            Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, Target.transform.position, 0.20f);
        }

        if (Sphere.transform.position == Target.transform.position)
        {
            Sphere.transform.position = new Vector3(0.0f, 0.0f, 4.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {
            Sphere = other.gameObject;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

}
