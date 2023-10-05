using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalesCubeSystem : MonoBehaviour
{
    // Creates a GameObject called UI_Shop and it is assigned with the UI_Shop script through Unity
    public GameObject UI_Shop;

    // Creates a gameobject that holds the UI Icons
    public GameObject UI_Icons;

    // Creates a PlayerController named pc and it is assigned with the PlayerController script through Unity
    public PlayerController pc;

    // Creates a keycode for the interact button
    public KeyCode InteractButton;

    // Variable used to detect the player
    bool player_detection = false;

    // Variable used to detect if the shop is open
    public bool open = false;

    // Update is called once per frame
    void Update()
    {
        // Checks if player_detection is true and if a certain key is pressed and if open is false
        if (player_detection == true && Input.GetKeyDown(InteractButton) && open == false && pc.playing == true && pc.open == false)
        {
            // Sets pc.playing to false
            pc.playing = false;
            // Disables the UI_Icons
            UI_Icons.SetActive(false);
            // Enables the shop
            UI_Shop.SetActive(true);
            // Sets open to true
            open = true;
            // Set cursor lock state to none, which allows the player to move the mouse freely
            Cursor.lockState = CursorLockMode.None;
            // Set cursor visibility to true
            Cursor.visible = true;
            // Set pc (created previously) playing to false
            pc.playing = false;
            return;
        }

        // Checks if player_detection is true and if a certain key is pressed and if open is true
        if (player_detection == true && Input.GetKeyDown(InteractButton) && open == true && pc.playing == false)
        {
            // Sets pc.playing to true
            pc.playing = true;
            if (pc.open == false)
            {
                // Enables the UI_Icons
                UI_Icons.SetActive(true);
            }
            // Disables the shop
            UI_Shop.SetActive(false);
            // Sets open to false
            open = false;
            // Set cursor lock state to locked, which prevents the cursor from leaving the game
            Cursor.lockState = CursorLockMode.Locked;
            // Set cursor visibility to false
            Cursor.visible = false;
            return;
        }
    }

    // Checks when something enters the sales cube sphere collider
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the thing that entered the collider has the Player tag
        if (other.tag == "Player")
        {
            // Changes player_detection to true
            player_detection = true;
        }
    }

    // Checks when something exits the sales cube sphere collider
    private void OnTriggerExit(Collider other)
    {
        // Changes player_detection to false
        player_detection = false;

        // Sets open to false
        open = false;

        // Enables the UI Icons
        UI_Icons.SetActive(true);

        // Disables the shop
        UI_Shop.SetActive(false);
    }
}
