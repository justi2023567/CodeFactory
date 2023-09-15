using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalesCubeSystem : MonoBehaviour
{
    public GameObject UI_Shop;

    public PlayerController pc;

    // Creates a keycode for the interact button
    public KeyCode InteractButton;

    public KeyCode buyButton1;
    public KeyCode buyButton2;
    public KeyCode buyButton3;
    public KeyCode buyButton4;

    public Inventory script;

    // Variable used to detect the player
    bool player_detection = false;

    // Variable used to detect if the shop is open
    bool open = false;

    // Update is called once per frame
    void Update()
    {
        // Checks if player_detection is true and if a certain key is pressed and if open is false
        if (player_detection && Input.GetKeyDown(InteractButton) && open == false)
        {
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
        }

        // Checks if player_detection is true and if a certain key is pressed and if open is true
        else if (player_detection && Input.GetKeyDown(InteractButton) && open)
        {
            // Disables the shop
            UI_Shop.SetActive(false);
            // Sets open to false
            open = false;
            // Set pc (created previously) playing to true
            pc.playing = true;
            // Set cursor lock state to locked, which prevents the cursor from leaving the game
            Cursor.lockState = CursorLockMode.Locked;
            // Set cursor visibility to false
            Cursor.visible = false;
        }

        if (player_detection && Input.GetKeyDown(buyButton1) && open && script.pogCount >= 10)
        {
            script.bronzePogCount++;
            script.pogCount -= 10;
        }
        if (player_detection && Input.GetKeyDown(buyButton2) && open && script.pogCount >= 100)
        {
            script.silverPogCount++;
            script.pogCount -= 100;
        }
        if (player_detection && Input.GetKeyDown(buyButton3) && open && script.pogCount >= 1000)
        {
            script.goldPogCount++;
            script.pogCount -= 1000;
        }
        if (player_detection && Input.GetKeyDown(buyButton4) && open && script.pogCount >= 10000)
        {
            script.diamondPogCount++;
            script.pogCount -= 10000;
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

        UI_Shop.SetActive(false);
        open = false;
    }
}
