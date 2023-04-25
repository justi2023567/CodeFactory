using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLock : MonoBehaviour
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
            //Cam controls
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //ttf.x = Mathf.Clamp(ttf.x, -60f, 60f);
            ttf.y -= Input.GetAxis("Mouse X") * pm.mousesens * (-1);
            tf.localRotation = Quaternion.Euler(25f, ttf.y, 0.0f);

            //End Cam controls

            PlayerBody.transform.parent = this.transform;

            Vector3 camF = tf.forward;
            Vector3 camR = tf.right;

            camF.y = 0;
            camF.y = 0;

            camF = camF.normalized;
            camR = camR.normalized;

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.position += camF * (pm.movespeed * pm.movespeedperc);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.position += camF * (pm.movespeed * pm.movespeedperc - .06f);
                transform.position -= camR * (pm.movespeed * pm.movespeedperc - .04f);
                return;
            }
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                transform.position += camF * (pm.movespeed * pm.movespeedperc - .06f);
                transform.position += camR * (pm.movespeed * pm.movespeedperc - .04f);
                return;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= camR * (pm.movespeed * pm.movespeedperc);
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.position -= camF * (pm.movespeed * pm.movespeedperc);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.position -= camF * (pm.movespeed * pm.movespeedperc - .06f);
                transform.position -= camR * ((pm.movespeed * pm.movespeedperc) * .1f);
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                transform.position -= camF * (pm.movespeed * pm.movespeedperc - .06f);
                transform.position += camR * ((pm.movespeed * pm.movespeedperc) * .1f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += camR * (pm.movespeed * pm.movespeedperc);
            }
            //reset = false;
        }
    }
}
