using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFree : MonoBehaviour
{
    public Transform tf;
    public Quaternion ttf;

    public GameObject PlayerBody;

    public PlayerController pm;

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (pm.playing == true)
        {
            this.transform.parent = null;

            //Cam controls
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            ttf.x += Input.GetAxis("Mouse Y") * pm.mousesens * (-1);
            ttf.x = Mathf.Clamp(ttf.x, -60f, 60f);

            ttf.y -= Input.GetAxis("Mouse X") * pm.mousesens * (-1);

            tf.localRotation = Quaternion.Euler(ttf.x, ttf.y, ttf.z);

            //End Cam controls

            Vector3 camF = tf.forward;
            Vector3 camR = tf.right;

            camF = camF.normalized;
            camR = camR.normalized;

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.position += camF * pm.movespeed * pm.movespeedperc;
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.position += camF * pm.movespeed * pm.movespeedperc;
            }
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                transform.position += camF * pm.movespeed * pm.movespeedperc;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= camR * pm.movespeed * pm.movespeedperc;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= camF * pm.movespeed * pm.movespeedperc;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += camR * pm.movespeed * pm.movespeedperc;
            }
        }
    }
}
