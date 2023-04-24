using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float movespeedperc;
    public bool playing = true;
    public Transform tf;
    public Quaternion ttf;
    public GameObject SettingsMenu;

    public GameObject Cam1SnapPos;

    public KeyCode CameraStateKey;

    public Camera playerCamera;
    public float mousesens;
    public float rotationX;
    public float rotationY;
    public int CameraState = 1;

    public float axisY;

    public Slider MovementSpeed;
    public Slider MouseSensitivity;
    public Dropdown CameraToggleKey;

    public GameObject PlayerBody;

    public bool reset;

    // Start is called before the first frame update
    public void Start()
    {
        ttf = tf.transform.localRotation;
    }

    public void Update()
    {
        movespeed = MovementSpeed.value;
        mousesens = MouseSensitivity.value;

        if (Input.GetKeyDown(KeyCode.Escape) && playing == true)
        {
            playing = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SettingsMenu.SetActive(true);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && playing == false)
        {
            playing = true;
            SettingsMenu.SetActive(false);
            return;
        }

        CameraStateKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), CameraToggleKey.options[CameraToggleKey.value].text);
        if (Input.GetKeyDown(CameraStateKey) && CameraState == 2)
        {
            CameraState = 1;
            reset = true;
            return;
        }
        if (Input.GetKeyDown(CameraStateKey) && CameraState == 1)
        {
            CameraState = 2;
            reset = true;
            return;
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (playing == true)
        {
            if (CameraState == 1)
            {
                this.transform.position = Cam1SnapPos.transform.position;

                //Cam controls
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                //ttf.x += Input.GetAxis("Mouse Y") * mousesens * (-1);

                if (reset == true)
                {
                    Debug.Log(PlayerBody.transform.rotation.y * 180);
                    ttf.y = PlayerBody.transform.rotation.y * 180;
                }
                else
                {
                    ttf.y -= Input.GetAxis("Mouse X") * mousesens * (-1);
                }

                //ttf.x = Mathf.Clamp(ttf.x, -60f, 60f);
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
                    transform.position += camF * (movespeed * movespeedperc);
                }
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position += camF * (movespeed * movespeedperc - .06f);
                    transform.position -= camR * (movespeed * movespeedperc - .04f);
                    return;
                }
                if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    transform.position += camF * (movespeed * movespeedperc - .06f);
                    transform.position += camR * (movespeed * movespeedperc - .04f);
                    return;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= camR * (movespeed * movespeedperc);
                }
                if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position -= camF * (movespeed * movespeedperc);
                }
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position -= camF * (movespeed * movespeedperc - .06f);
                    transform.position -= camR * ((movespeed * movespeedperc) * .1f);
                }
                if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    transform.position -= camF * (movespeed * movespeedperc - .06f);
                    transform.position += camR * ((movespeed * movespeedperc) * .1f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += camR * (movespeed * movespeedperc);
                }
                reset = false;
            }
            if (CameraState == 2)
            {
                PlayerBody.transform.parent = null;

                //Cam controls
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                ttf.x += Input.GetAxis("Mouse Y") * mousesens * (-1);

                ttf.y -= Input.GetAxis("Mouse X") * mousesens * (-1);

                //ttf.x = Mathf.Clamp(ttf.x, -60f, 60f);

                tf.localRotation = Quaternion.Euler(ttf.x, ttf.y, 0.0f);

                //End Cam controls

                Vector3 camF = tf.forward;
                Vector3 camR = tf.right;

                camF.y = 0;
                camF.y = 0;

                camF = camF.normalized;
                camR = camR.normalized;

                if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position += camF * (movespeed * movespeedperc);
                }
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position += camF * (movespeed * movespeedperc - .06f);
                    transform.position -= camR * (movespeed * movespeedperc - .04f);
                    return;
                }
                if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    transform.position += camF * (movespeed * movespeedperc - .06f);
                    transform.position += camR * (movespeed * movespeedperc - .04f);
                    return;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= camR * (movespeed * movespeedperc);
                }
                if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position -= camF * (movespeed * movespeedperc);
                }
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    transform.position -= camF * (movespeed * movespeedperc - .06f);
                    transform.position -= camR * ((movespeed * movespeedperc) * .1f);
                }
                if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    transform.position -= camF * (movespeed * movespeedperc - .06f);
                    transform.position += camR * ((movespeed * movespeedperc) * .1f);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += camR * (movespeed * movespeedperc);
                }
            }
        }
    }
}
