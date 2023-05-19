using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public float movespeedperc;
    public bool playing = true;
    public Transform tf;
    public Quaternion ttf;
    public GameObject SettingsMenu;
    public GameObject InventoryMenu;

    public Event keyHappen;

    public GameObject Cam1SnapPos;

    public PlayerMovementLock LockActivate;
    public PlayerMovementFree FreeActivate;

    public KeyCode CameraStateKey;
    public KeyCode InventoryStateKey;

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

    public Text CamText;

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

        if (Input.GetKeyDown(CameraStateKey) && CameraState == 2)
        {
            CamText.text = "Lock Cam";
            CamText.color = new Color(255, 0, 0, 255);
            ttf.y = 0;
            //ttf.y = PlayerBody.transform.rotation.y;
            this.transform.position = Cam1SnapPos.transform.position;
            this.transform.rotation = Cam1SnapPos.transform.rotation;
            CameraState = 1;
            reset = true;
            return;
        }
        if (Input.GetKeyDown(CameraStateKey) && CameraState == 1)
        {
            CamText.text = "Free Cam";
            CamText.color = new Color(0, 255, 0, 255);
            FreeActivate.ttf.y = LockActivate.ttf.y;
            CameraState = 2;
            reset = true;
            return;
        }
        if (Input.GetKeyDown(InventoryStateKey) && playing == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            InventoryMenu.SetActive(true);
            playing = false;
            return;
        }
        if (Input.GetKeyDown(InventoryStateKey) && playing == false)
        {
            InventoryMenu.SetActive(false);
            playing = true;
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
                LockActivate.enabled = true;
                FreeActivate.enabled = false;
            }
            if (CameraState == 2)
            {
                LockActivate.enabled = false;
                FreeActivate.enabled = true;
            }
        }
    }
}
