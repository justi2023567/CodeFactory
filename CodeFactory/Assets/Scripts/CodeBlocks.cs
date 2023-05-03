using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlocks : MonoBehaviour
{
    public GameObject CodeBlocksMenu;
    public KeyCode InteractButton;

    public float firerate;
    public float nextfire;

    public bool open = false;

    public bool ready = false;

    public CheckBlocks controller;

    public PlayerController pc;

    public GameObject LastCollided;

    public void Update()
    {
        if (Time.time > nextfire && ready == true)
        {
            nextfire = Time.time + firerate;
            if (Input.GetKeyDown(InteractButton) && open == true)
            {
                pc.playing = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Debug.Log("Deactivate Menu");
                CodeBlocksMenu.SetActive(false);
                open = false;
                return;
            }
            if (Input.GetKeyDown(InteractButton) && open == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pc.playing = false;
                Debug.Log("Activate Menu");
                CodeBlocksMenu.SetActive(true);
                open = true;
                return;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ready = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ready = false;
        other.GetComponent<WalkBotScript>().code = controller.code;
    }
}
