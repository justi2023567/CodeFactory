using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPoint : MonoBehaviour
{
    public GameObject player;

    public float Y = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation = new Quaternion(90, 0, 0, 1);

        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, -Vector3.up, out hit))
        {
            if (hit.distance < 2f)
            {
                if (Y == 0)
                {
                    Y = player.transform.position.y;
                }
                if (Y > player.transform.position.y)
                {
                    player.transform.position = new Vector3(player.transform.position.x, Y, player.transform.position.z);
                }
            }
            else if (hit.distance > 2f)
            {
                Y = 0f;
            }
        }
    }
}
