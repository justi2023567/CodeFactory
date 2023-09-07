using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesCubeSystem : MonoBehaviour
{
    // Creates a keycode for the interact button
    public KeyCode InteractButton;

    // Variable used to detect the player
    bool player_detection = false;

    // Update is called once per frame
    void Update()
    {
        // Checks if player_detection is true and if a certain key is pressed
        if (player_detection && Input.GetKeyDown(InteractButton))
        {
            print("Dialogue triggered");
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
    }
}
