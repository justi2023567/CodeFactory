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

    public CheckBlocks controller;

    public PlayerController pc;

    public GameObject LastCollided;

    public void Update()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            if (Input.GetKeyDown(InteractButton) && open == true)
            {
                pc.playing = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                CodeBlocksMenu.SetActive(false);
                open = false;
                return;
            }
            if (Input.GetKeyDown(InteractButton) && open == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pc.playing = false;
                CodeBlocksMenu.SetActive(true);
                open = true;
                return;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bot" && controller.error == false)
        {
            other.GetComponent<WalkBotScript>().code = controller.code;
        }
    }
}
