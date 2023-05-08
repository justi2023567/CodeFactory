using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptedCamColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().isKinematic = true;
    }
}
