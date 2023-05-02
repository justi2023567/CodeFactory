using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlocks : MonoBehaviour
{
    public GameObject CodeBlocksMenu;
    public KeyCode InteractButton;

    public bool open = false;

    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
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
