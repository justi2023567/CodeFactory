using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.position.y, this.transform.position.z, 1);
    }
}
