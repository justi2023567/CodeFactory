using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalesCubeSystem : MonoBehaviour
{
    // Creates a keycode for the interact button
    public KeyCode InteractButton;

    public GameObject d_template;
    public GameObject canva;

    // Variable used to detect the player
    bool player_detection = false;

    // Update is called once per frame
    void Update()
    {
        // Checks if player_detection is true and if a certain key is pressed and if dialogue is false (dialogue in PlayerController.cs)
        if (player_detection && Input.GetKeyDown(InteractButton) && !PlayerController.dialogue)
        {
            canva.SetActive(true);
            // Enables the dialogue (dialogue becomes true)
            PlayerController.dialogue = true;
            NewDialogue("Hello There");
            NewDialogue("This is a test");
            NewDialogue("To see if this system works");
            NewDialogue("Bye");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
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
