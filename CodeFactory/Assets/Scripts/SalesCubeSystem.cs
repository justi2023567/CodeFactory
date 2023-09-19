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
    public KeyCode buyButton5;
    public KeyCode buyButton6;
    public KeyCode buyButton7;
    public KeyCode buyButton8;
    public KeyCode buyButton9;
    public KeyCode buyButton10;

    public Inventory script;

    // Variable used to detect the player
    bool player_detection = false;

    // Variable used to detect if the shop is open
    bool open = false;

    // Update is called once per frame
    void Update()
    {
        // Checks if player_detection is true and if a certain key is pressed and if open is false
        if (player_detection == true && Input.GetKeyDown(InteractButton) && open == false)
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
            return;
        }

        // Checks if player_detection is true and if a certain key is pressed and if open is true
        if (player_detection == true && Input.GetKeyDown(InteractButton) && open == true)
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
            return;
        }

        // Checks if player_detection is true and the correct button is pressed down and you meet the requirements to buy the item
        if (player_detection == true && Input.GetKeyDown(buyButton1) && open == true && script.pogCount >= 10)
        {
            script.bronzePogCount++;
            script.pogCount -= 10;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton2) && open == true && script.pogCount >= 100)
        {
            script.silverPogCount++;
            script.pogCount -= 100;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton3) && open == true && script.bronzePogCount >= 10)
        {
            script.silverPogCount++;
            script.bronzePogCount -= 10;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton4) && open == true && script.pogCount >= 1000)
        {
            script.goldPogCount++;
            script.pogCount -= 1000;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton5) && open == true && script.bronzePogCount >= 100)
        {
            script.goldPogCount++;
            script.bronzePogCount -= 100;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton6) && open == true && script.silverPogCount >= 10)
        {
            script.goldPogCount++;
            script.silverPogCount -= 10;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton7) && open == true && script.pogCount >= 10000)
        {
            script.diamondPogCount++;
            script.pogCount -= 10000;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton8) && open == true && script.bronzePogCount >= 1000)
        {
            script.diamondPogCount++;
            script.bronzePogCount -= 1000;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton9) && open == true && script.silverPogCount >= 100)
        {
            script.diamondPogCount++;
            script.silverPogCount -= 100;
            return;
        }
        if (player_detection == true && Input.GetKeyDown(buyButton10) && open == true && script.goldPogCount >= 10)
        {
            script.diamondPogCount++;
            script.goldPogCount -= 10;
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

        UI_Shop.SetActive(false);
        open = false;
    }
}
